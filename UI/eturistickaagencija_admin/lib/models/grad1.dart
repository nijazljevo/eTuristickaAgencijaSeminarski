
import 'package:json_annotation/json_annotation.dart';
part 'grad1.g.dart';
@JsonSerializable()
class Grad1{
  int? Id;
  String? naziv;
  int? drzavaId;

  Grad1(this.Id,this.naziv,this.drzavaId);

factory Grad1.fromJson(Map<String,dynamic>json)=>_$Grad1FromJson(json);
Map<String,dynamic>toJson()=>_$Grad1ToJson(this);
}