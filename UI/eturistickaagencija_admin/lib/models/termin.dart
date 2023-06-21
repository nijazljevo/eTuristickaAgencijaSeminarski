import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'termin.g.dart';

@JsonSerializable()
class Termin{
int? id;
int? destinacijaId;
double? cijena;
double? popust;
int? hotelId;
double? cijenaPopust;
bool? aktivniTermin;
DateTime? datumPolaska;
DateTime? datumDolaska;
int? gradId;


Termin(this.id,this.destinacijaId,this.cijena,this.popust,this.hotelId,this.cijenaPopust,this.aktivniTermin,this.datumPolaska,this.datumDolaska,this.gradId);

factory Termin.fromJson(Map<String,dynamic>json)=>_$TerminFromJson(json);
Map<String,dynamic>toJson()=>_$TerminToJson(this);
}
