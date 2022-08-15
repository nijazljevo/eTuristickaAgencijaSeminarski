import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:myapp/model/hotel.dart';
import 'package:myapp/providers/base_provider.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

class HotelProvider extends BaseProvider<Hotel> {
  HotelProvider() : super("Hoteli");

  @override
  Hotel fromJson(data) {
    return Hotel.fromJson(data);
  }
}