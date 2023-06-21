import 'package:json_annotation/json_annotation.dart';

part 'karta.g.dart';

@JsonSerializable()
class Karta{
int? id;
int? terminId;
int? korisnikId;
DateTime? datumKReiranja;
bool? ponistena;

Karta(this.id,this.terminId,this.korisnikId,this.datumKReiranja,this.ponistena);

factory Karta.fromJson(Map<String,dynamic>json)=>_$KartaFromJson(json);
Map<String,dynamic>toJson()=>_$KartaToJson(this);
}
