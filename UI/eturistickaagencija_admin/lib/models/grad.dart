
import 'package:json_annotation/json_annotation.dart';
part 'grad.g.dart';
@JsonSerializable()
class Grad{
  int? Id;
  String? naziv;
  int? drzavaId;

  Grad(this.Id,this.naziv,this.drzavaId);

factory Grad.fromJson(Map<String,dynamic>json)=>_$GradFromJson(json);
Map<String,dynamic>toJson()=>_$GradToJson(this);
}