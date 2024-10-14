function storeMovies(movies) {
  let movieCatalog = [];

  movies.map((movie) => {
    if (movie.includes("addMovie ")) {
      const [_, name] = movie.split("addMovie ");
      movieCatalog.push({
        name,
        director: null,
        date: null,
      });
    }

    if (movie.includes(" directedBy ")) {
      const [name, director] = movie.split(" directedBy ");

      const searchMovie = movieCatalog.find((m) => m.name === name);

      if (searchMovie) {
        searchMovie.director = director;
      }
    }

    if (movie.includes(" onDate ")) {
      const [name, date] = movie.split(" onDate ");

      const searchMovie = movieCatalog.find((m) => m.name === name);

      if (searchMovie) {
        searchMovie.date = date;
      }
    }
  });

  movieCatalog.forEach((m) => {
    if (m.director && m.date && m.name) {
      console.log(JSON.stringify(m));
    }
  });
}

// storeMovies([
//   "addMovie The Avengers",
//   "addMovie Superman",
//   "The Avengers directedBy Anthony Russo",
//   "The Avengers onDate 30.07.2010",
//   "Captain America onDate 30.07.2010",
//   "Captain America directedBy Joe Russo",
// ]);
