import 'dart:ffi';
import 'package:json_annotation/json_annotation.dart';

part 'destinacije.g.dart';

@JsonSerializable()
class Destinacije{
  int? destinacijaId;
  String? naziv;
  String? slika;

  Destinacije(){}
  
  factory Destinacije.fromJson(Map<String, dynamic> json) => _$DestinacijeFromJson(json);

  /// Connect the generated [_$DestinacijeToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$DestinacijeToJson(this);
}