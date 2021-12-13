# BookLibrary
Ilk once 2 gun erzinde UnitOfWork ve Repsoitory pattern oyrenerek yazmaga calisdigim 
ucun buttun funksionalliqlari ve duzgun dokumentasiya mentiqini catdira bilmediyimi ve qarsilasacaginiz errorlarin bir coxunun(null-lari check etmek kimi ve s.) 
eslinde aglimda oldugunu sadece vaxt catdira bilmediyimi qeyd edim.

BookController APIs

Get API: Get requestdir istenilen kitabin id-si daxil edilir.
Request: localhost/Book/5

Book Insert API: Post Requestdir ve Bodysinde aid oldugu genreler ve authorlarin sadece id-si goturulur.(Yeni onceden dbda genre ve authorlar olmalidir)
Request : 
{
  "title": "Mavi Qatarin sirri",
  "description": "Detektifdir.Maraqlidir",
  "bookAuthors": [
    {
      "authorId": 2
    },
   {
      "authorId": 3
    }
  ],
  "bookGenres": [
    {
      "genreId": 1
    },
{
      "genreId": 2
    }
  ]
}

Book Update API: Put Requestdir ve Bodysinde 
Request : 
{
  "id": 7,
  "title": "test",
  "description": "test",
  "bookAuthors": [
    {
      "authorId": 1
    }
  ],
  "bookGenres": [
    {
      "genreId": 3
    }
  ]
}

Delete API: Remove edilecek book-un id-si daxil edilir.Delete Requestdir.
Request: localhost/Book/5

Get book by genre: Get requestdir.Request-de gonderilecek janrin idsi qeyd olunur.
Request: localhost/api/book/genre/id

AuthorController, GenreController
GetTopEntities API:
Get Top Five Author: Get requestdir. 5 en cox kitaba sahib muellifleri qaytarir.
Get Top Five Genre: Get requestdir. 5 en cox kitaba sahib janri qaytarir.
