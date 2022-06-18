// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'product.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Product _$ProductFromJson(Map<String, dynamic> json) => Product()
  ..hotelId = json['hotelId'] as int?
  ..naziv = json['naziv'] as String?
  ..slika = json['slika'] as String?
  ..brojZvjezdica=json['brojZvjezdica']as int?;

Map<String, dynamic> _$ProductToJson(Product instance) => <String, dynamic>{
     'hotelId': instance.hotelId,
     'naziv': instance.naziv,
     'slika': instance.slika,
     'brojZvjezdica':instance.brojZvjezdica,
    };