// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'hotel.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Hotel _$HotelFromJson(Map<String, dynamic> json) => Hotel()
  ..hotelId = json['hotelId'] as int?
  ..naziv = json['naziv'] as String?
  ..brojZvijezdica = json['brojZvijezdica'] as int?
  ..slika = json['slika'] as String?;

Map<String, dynamic> _$HotelToJson(Hotel instance) => <String, dynamic>{
      'hotelId': instance.hotelId,
      'naziv': instance.naziv,
      'slika': instance.slika,
      'brojZvijezdica': instance.brojZvijezdica,
    };