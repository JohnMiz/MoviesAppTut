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
		  public MainPage()
		  {
			   InitializeComponent();

			   listView.ItemsSource = new List<MovieInfo> {
					new MovieInfo{ ImageSource = "https://picsum.photos/50/50", Name ="Test", ReleaseYear="1999", Description="This is a test not a movie." },
					new MovieInfo{ ImageSource = "https://picsum.photos/50/50", Name ="Test1", ReleaseYear="1994", Description="This is a test not a movie."},
					new MovieInfo{ ImageSource = "https://picsum.photos/50/50", Name ="Test2", ReleaseYear="1993", Description="This is a test not a movie."},
			   };
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
	 }
}
