import 'package:json_annotation/json_annotation.dart';

part 'uposlenik.g.dart';

@JsonSerializable()
class Uposlenik{
int? id;
int? korisnikId;
DateTime? datumZaposlenja;
bool? aktivan;

Uposlenik(this.id,this.korisnikId,this.datumZaposlenja,this.aktivan);

factory Uposlenik.fromJson(Map<String,dynamic>json)=>_$UposlenikFromJson(json);
Map<String,dynamic>toJson()=>_$UposlenikToJson(this);
}
