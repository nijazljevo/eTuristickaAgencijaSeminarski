import 'dart:convert';
import 'package:eturistickaagencija_admin/providers/base_provider.dart';
import '../models/termin.dart';

class TerminProvider extends BaseProvider<Termin>{
  TerminProvider():super("Termini");

  @override
  Termin fromJson(data) {
    // TODO: implement fromJson
    return Termin.fromJson(data);
  }
}