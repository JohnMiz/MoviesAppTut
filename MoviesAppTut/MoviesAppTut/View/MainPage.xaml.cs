using MoviesAppTut.Models;
using MoviesAppTut.Services;
using MoviesAppTut.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviesAppTut
{
	 public partial class MainPage : ContentPage
	 {
		  private IMovieSearchDataService movieSearchDataService;

		  public MainPage()
		  {
			   InitializeComponent();

			   movieSearchDataService = new TMDBMovieSearchService();

			   

			   
		  }

		  private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		  {
			   var selectMovieInfo = e.SelectedItem as MovieInfo;

			   if (selectMovieInfo != null)
			   {
					await Navigation.PushAsync(new MovieInfoDetailPage(selectMovieInfo));
					listView.SelectedItem = null;
			   }
		  }

		  private async void searchBar_TextChanged(object sender, TextChangedEventArgs e)
		  {
			   var query = e.NewTextValue as string;

			   if(!string.IsNullOrEmpty(query))
			   {
					if(query.Length >= 4)
					{
						 loader.IsRunning = true;

						 var movies = await movieSearchDataService.GetMovieSearch(query);

						 if(movies.Count == 0)
						 {
							  searchBar.Text = "";
							  loader.IsRunning = false;
							  await DisplayAlert("Message", "Couldn't find movie.", "OK", "Cancel");
							  return;
						 }

						 listView.ItemsSource = movies;

						 loader.IsRunning = false;
					}
			   }
		  }
	 }
}
