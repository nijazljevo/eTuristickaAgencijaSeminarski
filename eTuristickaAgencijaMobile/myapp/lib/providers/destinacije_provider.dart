import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:myapp/models/destinacije.dart';
import 'package:myapp/providers/base_provider.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

class DestinacijeProvider extends BaseProvider<Destinacije> {
  DestinacijeProvider() : super("Destinacije");

  @override
  Destinacije fromJson(data) {
    return Destinacije.fromJson(data);
  }
}