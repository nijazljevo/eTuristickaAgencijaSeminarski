import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:myapp/models/drzave.dart';
import 'package:myapp/providers/base_provider.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

class DrzaveProvider extends BaseProvider<Drzave> {
  DrzaveProvider() : super("Drzave");

  @override
  Drzave fromJson(data) {
    return Drzave.fromJson(data);
  }
}