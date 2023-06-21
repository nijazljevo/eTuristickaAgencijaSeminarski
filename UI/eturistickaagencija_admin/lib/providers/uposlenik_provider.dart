import 'dart:convert';
import 'package:eturistickaagencija_admin/models/grad.dart';
import 'package:eturistickaagencija_admin/models/kontinent.dart';
import 'package:eturistickaagencija_admin/models/uposlenik.dart';
import 'package:eturistickaagencija_admin/providers/base_provider.dart';
import 'package:eturistickaagencija_admin/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:http/http.dart';

import '../models/hotel.dart';
import '../models/karta.dart';
import '../models/search_result.dart';

class UposlenikProvider extends BaseProvider<Uposlenik>{
  UposlenikProvider():super("Karte");

  @override
  Uposlenik fromJson(data) {
    // TODO: implement fromJson
    return Uposlenik.fromJson(data);
  }

}