# TopTenMoviesOfRightNow

Overview:
  TopTenMoviesOfRightNow is a web application that displays the top ten movies based on user submitted top ten lists. Allowing
  the user to resubmit their list every 10 minutes. A running top ten list will be stored in an Azure SQL Server, where each movie will
  be given a score that is used to determine the top ten. The user searches for movies using a search box that sends a request to
  TheMovieDB. The results are then displayed for the user to select which ones they want to add. Once the list is complete and the
  user submits it, the running top ten list will be displayed along with a button to allow the user to resubmit their list, which
  will only be available again after 10 minutes or so (exact time yet to be determined.

Try it Out: http://toptenmoviesofrightnow20170906103839.azurewebsites.net/TopTenMovies.aspx

Completed:
  The movie search functionality, although a bit crued, is complete. Users can also add and remove items to their list.
  
Current Task(s):
  Adding entities for the two SQL tables that will be used. 
  
Next Steps:
    Create a Caching layer to sit between the database and the WebApp, as well as the MovieDB api and the WebApp. 
    Clean up the UI. 
    Add functionality for TV shows, directors, actors, etc. 
    Add User Account functionality.
