import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:myapp/models/product.dart';
import 'package:myapp/providers/base_provider.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

class ProductProvider extends BaseProvider<Product> {
  ProductProvider() : super("Hoteli");

  @override
  Product fromJson(data) {
    return Product.fromJson(data);
  }
}