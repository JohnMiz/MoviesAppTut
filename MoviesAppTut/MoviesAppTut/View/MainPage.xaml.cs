using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviesAppTut
{
	 public class MovieInfo
	 {
		  public string ImageSource { get; set; }
		  public string Name { get; set; }
		  public string ReleaseYear { get; set; }
	 }

	 public partial class MainPage : ContentPage
	 {

		  public MainPage()
		  {
			   InitializeComponent();

			   listView.ItemsSource = new List<MovieInfo> {
					new MovieInfo{ ImageSource = "https://picsum.photos/50/50", Name ="Test", ReleaseYear="1999"},
					new MovieInfo{ ImageSource = "https://picsum.photos/50/50", Name ="Test1", ReleaseYear="1994"},
					new MovieInfo{ ImageSource = "https://picsum.photos/50/50", Name ="Test2", ReleaseYear="1993"},
			   };
		  }

		  private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		  {
			   Debug.WriteLine("selected");
		  }

		  private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
		  {
			   Debug.WriteLine("tapped");
		  }
	 }
}
