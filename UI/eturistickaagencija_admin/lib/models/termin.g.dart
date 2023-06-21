// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'termin.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Termin _$TerminFromJson(Map<String, dynamic> json) => Termin(
      json['id'] as int?,
      json['destinacijaId'] as int?,
      (json['cijena'] as num?)?.toDouble(),
      (json['popust'] as num?)?.toDouble(),
      json['hotelId'] as int?,
      (json['cijenaPopust'] as num?)?.toDouble(),
      json['aktivniTermin'] as bool?,
      json['datumPolaska'] == null
          ? null
          : DateTime.parse(json['datumPolaska'] as String),
      json['datumDolaska'] == null
          ? null
          : DateTime.parse(json['datumDolaska'] as String),
      json['gradId'] as int?,
    );

Map<String, dynamic> _$TerminToJson(Termin instance) => <String, dynamic>{
      'id': instance.id,
      'destinacijaId': instance.destinacijaId,
      'cijena': instance.cijena,
      'popust': instance.popust,
      'hotelId': instance.hotelId,
      'cijenaPopust': instance.cijenaPopust,
      'aktivniTermin': instance.aktivniTermin,
      'datumPolaska': instance.datumPolaska?.toIso8601String(),
      'datumDolaska': instance.datumDolaska?.toIso8601String(),
      'gradId': instance.gradId,
    };
