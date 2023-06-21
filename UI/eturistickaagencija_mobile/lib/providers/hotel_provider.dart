import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:eturistickaagencija_mobile/model/hotel.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

import 'base_provider.dart';

class HotelProvider extends BaseProvider<Hotel> {
  HotelProvider() : super("Hoteli");

  @override
  Hotel fromJson(data) {
    return Hotel.fromJson(data);
  }
}