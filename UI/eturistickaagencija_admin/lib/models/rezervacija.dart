import 'package:json_annotation/json_annotation.dart';

part 'rezervacija.g.dart';

@JsonSerializable()
class Rezervacija{
int? id;
double? cijena;
int? hotelId;
bool? otkazana;
DateTime? datumRezervacija;
int? korisnikId;

Rezervacija(this.id,this.cijena,this.hotelId,this.otkazana,this.datumRezervacija,this.korisnikId);

factory Rezervacija.fromJson(Map<String,dynamic>json)=>_$RezervacijaFromJson(json);
Map<String,dynamic>toJson()=>_$RezervacijaToJson(this);
}
