import 'dart:ffi';

import 'package:json_annotation/json_annotation.dart';

part 'hotel.g.dart';

@JsonSerializable()
class Hotel {
  int? hotelId;
  String? naziv;
  String? slika;
  int? brojZvijezdica;


  Hotel(){}

  factory Hotel.fromJson(Map<String, dynamic> json) => _$HotelFromJson(json);

  /// Connect the generated [_$HotelToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$HotelToJson(this);
}