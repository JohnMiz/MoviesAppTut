using MoviesAppTut.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesAppTut.View
{
	 [XamlCompilation(XamlCompilationOptions.Compile)]
	 public partial class MovieInfoDetailPage : ContentPage
	 {
		  public MovieInfoDetailPage(MovieInfo movieInfo)
		  {
			   InitializeComponent();

			   if (movieInfo != null)
					BindingContext = movieInfo;
			   else new ArgumentNullException("Movie info is null.");
		  }
	 }
}