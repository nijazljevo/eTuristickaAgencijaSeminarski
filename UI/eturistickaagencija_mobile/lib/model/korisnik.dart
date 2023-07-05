
import 'dart:convert';

class Korisnik {
  final int? id;
  final String ime;
  final String prezime;
  final String korisnikoIme;
  final String email;
  final String? password;
  final String? passwordPotvrda;
  final int? ulogaId;

  Korisnik({
    required this.id,
    required this.ime,
    required this.prezime,
    required this.korisnikoIme,
    required this.email,
    this.password,
    this.passwordPotvrda,
    this.ulogaId
  });

  factory Korisnik.fromJson(Map<String, dynamic> json) {
    return Korisnik(
      id: json["id"],
      ime: json['ime'],
      prezime: json['prezime'],
      korisnikoIme: json['korisnikoIme'],
      email: json['email'],
      password: json['password'],
      passwordPotvrda: json['passwordPotvrda'],
      ulogaId: json['ulogaId'],
    );
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "Ime": ime,
        "Prezime": prezime,
        "korisnikoIme": korisnikoIme,
        "email": email,
        "password": password,
        "passwordPotvrda": passwordPotvrda,
        "ulogaId":ulogaId
      };
}