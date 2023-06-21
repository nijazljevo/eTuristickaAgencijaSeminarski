// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'karta.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Karta _$KartaFromJson(Map<String, dynamic> json) => Karta(
      json['id'] as int?,
      json['terminId'] as int?,
      json['korisnikId'] as int?,
      json['datumKReiranja'] == null
          ? null
          : DateTime.parse(json['datumKReiranja'] as String),
      json['ponistena'] as bool?,
    );

Map<String, dynamic> _$KartaToJson(Karta instance) => <String, dynamic>{
      'id': instance.id,
      'terminId': instance.terminId,
      'korisnikId': instance.korisnikId,
      'datumKReiranja': instance.datumKReiranja?.toIso8601String(),
      'ponistena': instance.ponistena,
    };
