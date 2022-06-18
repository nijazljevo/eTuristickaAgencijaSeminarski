// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'destinacije.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Destinacije _$DestinacijeFromJson(Map<String, dynamic> json) => Destinacije()
  ..destinacijaId = json['destinacijaId'] as int?
  ..naziv = json['naziv'] as String?
  ..slika = json['slika'] as String?;

Map<String, dynamic> _$DestinacijeToJson(Destinacije instance) => <String, dynamic>{
     'destinacijaId': instance.destinacijaId,
     'naziv': instance.naziv,
     'slika': instance.slika,
    };