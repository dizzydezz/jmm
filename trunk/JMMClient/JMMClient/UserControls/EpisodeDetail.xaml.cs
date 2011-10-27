﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JMMClient.ViewModel;
using System.IO;

namespace JMMClient.UserControls
{
	/// <summary>
	/// Interaction logic for EpisodeDetail.xaml
	/// </summary>
	public partial class EpisodeDetail : UserControl
	{
		public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register("IsExpanded",
			typeof(bool), typeof(EpisodeDetail), new UIPropertyMetadata(false, isExpandedCallback));

		
		public bool IsExpanded
		{
			get { return (bool)GetValue(IsExpandedProperty); }
			set { 
				SetValue(IsExpandedProperty, value);
				SetVisibility();
			}
		}

		public static readonly DependencyProperty IsCollapsedProperty = DependencyProperty.Register("IsCollapsed",
			typeof(bool), typeof(EpisodeDetail), new UIPropertyMetadata(true, isCollapsedCallback));


		public bool IsCollapsed
		{
			get { return (bool)GetValue(IsCollapsedProperty); }
			set { 
				SetValue(IsCollapsedProperty, value);
				SetVisibility();
			}
		}

		public static readonly DependencyProperty ShowEpisodeImageInSummaryProperty = DependencyProperty.Register("ShowEpisodeImageInSummary",
			typeof(bool), typeof(EpisodeDetail), new UIPropertyMetadata(true, null));


		public bool ShowEpisodeImageInSummary
		{
			get { return (bool)GetValue(ShowEpisodeImageInSummaryProperty); }
			set { SetValue(ShowEpisodeImageInSummaryProperty, value); }
		}

		public static readonly DependencyProperty ShowEpisodeOverviewInSummaryProperty = DependencyProperty.Register("ShowEpisodeOverviewInSummary",
			typeof(bool), typeof(EpisodeDetail), new UIPropertyMetadata(true, null));


		public bool ShowEpisodeOverviewInSummary
		{
			get { return (bool)GetValue(ShowEpisodeOverviewInSummaryProperty); }
			set { SetValue(ShowEpisodeOverviewInSummaryProperty, value); }
		}

		public static readonly DependencyProperty ShowEpisodeImageInExpandedProperty = DependencyProperty.Register("ShowEpisodeImageInExpanded",
			typeof(bool), typeof(EpisodeDetail), new UIPropertyMetadata(true, null));


		public bool ShowEpisodeImageInExpanded
		{
			get { return (bool)GetValue(ShowEpisodeImageInExpandedProperty); }
			set { SetValue(ShowEpisodeImageInExpandedProperty, value); }
		}

		public static readonly DependencyProperty ShowEpisodeOverviewInExpandedProperty = DependencyProperty.Register("ShowEpisodeOverviewInExpanded",
			typeof(bool), typeof(EpisodeDetail), new UIPropertyMetadata(true, null));


		public bool ShowEpisodeOverviewInExpanded
		{
			get { return (bool)GetValue(ShowEpisodeOverviewInExpandedProperty); }
			set { SetValue(ShowEpisodeOverviewInExpandedProperty, value); }
		}

		private static void isExpandedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			EpisodeDetail input = (EpisodeDetail)d;
			//input.tbTest.Text = e.NewValue as string;
		}

		private static void isCollapsedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			EpisodeDetail input = (EpisodeDetail)d;
			//input.tbTest.Text = e.NewValue as string;
		}

		private void SetVisibility()
		{
			AnimeEpisodeVM ep = this.DataContext as AnimeEpisodeVM;
			if (ep != null)
			{
				ShowEpisodeImageInSummary = IsCollapsed && ep.ShowEpisodeImageInSummary;
				ShowEpisodeOverviewInSummary = IsCollapsed && ep.ShowEpisodeOverviewInSummary;

				ShowEpisodeImageInExpanded = IsExpanded && ep.ShowEpisodeImageInExpanded;
				ShowEpisodeOverviewInExpanded = IsExpanded && ep.ShowEpisodeOverviewInExpanded;
			}
		}

		public EpisodeDetail()
		{
			InitializeComponent();

			btnToggleExpander.Click += new RoutedEventHandler(btnToggleExpander_Click);
			this.DataContextChanged += new DependencyPropertyChangedEventHandler(EpisodeDetail_DataContextChanged);
			this.Loaded += new RoutedEventHandler(EpisodeDetail_Loaded);
		}

		void EpisodeDetail_Loaded(object sender, RoutedEventArgs e)
		{
			DependencyObject parentObject = VisualTreeHelper.GetParent(this);
			while (parentObject != null)
			{
				parentObject = VisualTreeHelper.GetParent(parentObject);
				AnimeSeries seriesControl = parentObject as AnimeSeries;
				if (seriesControl != null)
				{
					double gridWidth = seriesControl.ActualWidth - 40;
					if (gridWidth > 0)
						epDetailMainGrid.Width = gridWidth;
					return;
				}
			}
		}

		void EpisodeDetail_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			SetVisibility();
		}

		private void CommandBinding_OpenFolder(object sender, ExecutedRoutedEventArgs e)
		{
			object obj = e.Parameter;
			if (obj == null) return;

			try
			{
				if (obj.GetType() == typeof(VideoDetailedVM))
				{
					VideoDetailedVM vid = obj as VideoDetailedVM;

					if (File.Exists(vid.FullPath))
					{
						Utils.OpenFolderAndSelectFile(vid.FullPath);
					}
					else
					{
						MessageBox.Show(Properties.Resources.MSG_ERR_FileNotFound, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
			}
			catch (Exception ex)
			{
				Utils.ShowErrorMessage(ex);
			}
		}

		private void CommandBinding_DeleteLink(object sender, ExecutedRoutedEventArgs e)
		{
			Window parentWindow = Window.GetWindow(this);

			object obj = e.Parameter;
			if (obj == null) return;

			try
			{
				if (obj.GetType() == typeof(VideoDetailedVM))
				{
					VideoDetailedVM vid = obj as VideoDetailedVM;
					AnimeEpisodeVM ep = this.DataContext as AnimeEpisodeVM;
					//AnimeEpisodeVM ep = MainListHelperVM.Instance.GetEpisodeForVideo(vid, ((MainWindow)parentWindow).epListMain);

					string res = JMMServerVM.Instance.clientBinaryHTTP.RemoveAssociationOnFile(vid.VideoLocalID, ep.AniDB_EpisodeID);
					if (res.Length > 0)
					{
						MessageBox.Show(res, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					}
					else
					{
						if (ep != null)
						{
							MainListHelperVM.Instance.UpdateHeirarchy(ep);
							DisplayFiles();
						}
					}
				}
			}
			catch (Exception ex)
			{
				Utils.ShowErrorMessage(ex);
			}
		}

		private void CommandBinding_DeleteFile(object sender, ExecutedRoutedEventArgs e)
		{
			Window parentWindow = Window.GetWindow(this);

			object obj = e.Parameter;
			if (obj == null) return;

			try
			{
				if (obj.GetType() == typeof(VideoDetailedVM))
				{
					VideoDetailedVM vid = obj as VideoDetailedVM;
					AnimeEpisodeVM ep = this.DataContext as AnimeEpisodeVM;

					MessageBoxResult res = MessageBox.Show(string.Format("Are you sure you want to delete this file, the physical video file will also be deleted"),
						"Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);

					if (res == MessageBoxResult.Yes)
					{
						this.Cursor = Cursors.Wait;
						string result = JMMServerVM.Instance.clientBinaryHTTP.DeleteVideoLocalAndFile(vid.VideoLocalID);
						if (result.Length > 0)
							MessageBox.Show(result, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						else
						{
							// find the entry and remove it
							if (ep != null)
							{
								MainListHelperVM.Instance.UpdateHeirarchy(ep);
								DisplayFiles();
							}
							
						}
					}
				}
			}
			catch (Exception ex)
			{
				Utils.ShowErrorMessage(ex);
			}
			finally
			{
				this.Cursor = Cursors.Arrow;
			}
		}

		private void CommandBinding_PlayVideo(object sender, ExecutedRoutedEventArgs e)
		{
			Window parentWindow = Window.GetWindow(this);

			object obj = e.Parameter;
			if (obj == null) return;

			try
			{
				if (obj.GetType() == typeof(VideoDetailedVM))
				{
					VideoDetailedVM vid = obj as VideoDetailedVM;
					//AnimeEpisodeVM ep = this.DataContext as AnimeEpisodeVM;
					Utils.PlayVideo(vid);
				}
			}
			catch (Exception ex)
			{
				Utils.ShowErrorMessage(ex);
			}
		}

		private void CommandBinding_PlayEpisode(object sender, ExecutedRoutedEventArgs e)
		{
			Window parentWindow = Window.GetWindow(this);

			try
			{
				AnimeEpisodeVM ep = this.DataContext as AnimeEpisodeVM;
				ep.RefreshFilesForEpisode();

				if (ep.FilesForEpisode.Count > 0)
					Utils.PlayVideo(ep.FilesForEpisode[0]);
			}
			catch (Exception ex)
			{
				Utils.ShowErrorMessage(ex);
			}
		}

		public void DisplayFiles()
		{
			try
			{
				AnimeEpisodeVM ep = this.DataContext as AnimeEpisodeVM;
				if (ep != null)
				{
					ep.RefreshFilesForEpisode();
					lbFiles.ItemsSource = ep.FilesForEpisode;

					if (!ep.HasFiles)
					{
						List<AniDBReleaseGroupVM> relGroups = ep.ReleaseGroups;
						if (relGroups.Count > 0)
						{
							string grpList = "";
							foreach (AniDBReleaseGroupVM rg in relGroups)
							{
								if (grpList.Length > 0)
									grpList += ", ";
								grpList += rg.GroupName;
							}
							tbFileDetailsGroups.Text = JMMClient.Properties.Resources.GroupsAvailableFrom + " " + grpList;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Utils.ShowErrorMessage(ex);
			}
		}

		void btnToggleExpander_Click(object sender, RoutedEventArgs e)
		{
			IsExpanded = !IsExpanded;
			IsCollapsed = !IsCollapsed;

			if (IsExpanded)
			{
				DisplayFiles();
			}
		}
	}
}