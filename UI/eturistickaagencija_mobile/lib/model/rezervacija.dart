class Rezervacije {
  final int? id;
  int hotelId;
  int korisnikId;
  DateTime datumRezervacije;
  bool otkazana;
  double cijena;

  Rezervacije({
    this.id,
    required this.hotelId,
    required this.korisnikId,
    required this.datumRezervacije,
    required this.otkazana,
    required this.cijena,
  });

  Map<String, dynamic> toJson() {
    return {
      'id':id,
      'hotelId': hotelId,
      'korisnikId': korisnikId,
      'datumRezervacije': datumRezervacije.toIso8601String(),
      'otkazana': otkazana,
      'cijena': cijena,
    };
  }
}
