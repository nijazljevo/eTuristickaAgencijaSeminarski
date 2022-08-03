class Korisnik {
  String ime;
  String prezime;
  String email;
  String KorisnikoIme;

  Korisnik(
      {required this.ime,
      required this.prezime,
      required this.email,
      required this.KorisnikoIme});

  factory Korisnik.fromJson(Map<String, dynamic> json) {
    return Korisnik(
        ime: json["ime"],
        prezime: json["prezime"],
        email: json["email"],
        KorisnikoIme: json["KorisnikoIme"]);
  }

  Map<String, dynamic> toJson() => {
        "ime": ime,
        "prezime": prezime,
        "email": email,
        "KorisnikoIme": KorisnikoIme
      };
}