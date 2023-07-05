import 'dart:convert';
import 'dart:io';
import 'package:http/http.dart' as http;

import '../model/korisnik.dart';

class APIService {
  static String? username;
  static String? password;
  static int? korisnikId;
  static const String baseRoute = "http://10.0.2.2:5011/api/";
  String? route;

  APIService({this.route});

  static Future<Korisnik?> prijava() async {
    // ignore: prefer_interpolation_to_compose_strings
    String baseUrl = baseRoute + "Korisnici/";

    final String basicAuth =
        // ignore: prefer_interpolation_to_compose_strings
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
        

    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );
    if (response.statusCode == 200) {
      var responseData = json.decode(response.body);
      if (responseData is List) {
        if (responseData.isNotEmpty) {
          for (var korisnikData in responseData) {
            if (korisnikData['korisnikoIme'] == username) {
              return Korisnik.fromJson(korisnikData);
            }
          }
        }
      }
    }

    return null;
  }

  static Future<Korisnik?> fetchKorisnik(int id) async {
    // ignore: prefer_interpolation_to_compose_strings
    String baseUrl = baseRoute + "Korisnici/" + id.toString();

    final String basicAuth =
        // ignore: prefer_interpolation_to_compose_strings
        'Basic ' + base64Encode(utf8.encode('$username:$password'));

    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );

    if (response.statusCode == 200) {
      return Korisnik.fromJson(json.decode(response.body));
    }

    return null;
  }

  // ignore: non_constant_identifier_names
  static Future<dynamic> GetById(String route, int id) async {
    // ignore: prefer_interpolation_to_compose_strings
    String baseUrl = baseRoute + route + "/" + id.toString();

    final String basicAuth =
        // ignore: prefer_interpolation_to_compose_strings
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );
    if (response.statusCode == 200) {
      return json.decode(response.body);
    }

    return null;
  }

  static Future<List<dynamic>?> get(String route, dynamic object) async {
    String queryString;
    String baseUrl = baseRoute + route;

    if (object != null) {
      if (object is int) {
        // ignore: prefer_interpolation_to_compose_strings
        baseUrl = baseUrl + '/' + object.toString();
      } else {
        queryString = Uri(queryParameters: object).query;
        // ignore: prefer_interpolation_to_compose_strings
        baseUrl = baseUrl + '?' + queryString;
      }
    }

    final String basicAuth =
        // ignore: prefer_interpolation_to_compose_strings
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(Uri.parse(baseUrl),
        headers: {HttpHeaders.authorizationHeader: basicAuth});
    // ignore: avoid_print, prefer_interpolation_to_compose_strings
    print('Status code [GET] -> ' + response.statusCode.toString());
    if (response.statusCode == 200) {
      return json.decode(response.body) as List;
    }
    return null;
  }
  static Future<List<dynamic>?> getPreporuceno(String route, dynamic object) async {
  String queryString;
  String baseUrl = baseRoute + route;

  if (object != null) {
    if (object is int) {
      // ignore: prefer_interpolation_to_compose_strings
      baseUrl = baseUrl + '/' + object.toString();
    } else {
      queryString = Uri(queryParameters: object).query;
      // ignore: prefer_interpolation_to_compose_strings
      baseUrl = baseUrl + '?' + queryString;
    }
  }

  final String basicAuth =
      // ignore: prefer_interpolation_to_compose_strings
      'Basic ' + base64Encode(utf8.encode('$username:$password'));
  final response = await http.get(Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth});
  // ignore: prefer_interpolation_to_compose_strings, avoid_print
  print('Status code [GET] -> ' + response.statusCode.toString());
  if (response.statusCode == 200) {
    return json.decode(response.body) as List<dynamic>?; 
  }
  return null;
}


  static Future<dynamic> post(String route, String body) async {
    String baseUrl = baseRoute + route;

    final String basicAuth =
        // ignore: prefer_interpolation_to_compose_strings
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.post(
      Uri.parse(baseUrl),
      headers: {
        HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
        HttpHeaders.authorizationHeader: basicAuth
      },
      body: body,
    );

    // ignore: avoid_print, prefer_interpolation_to_compose_strings
    print('Status code [POST] -> ' + response.statusCode.toString());
    if (response.statusCode == 200) {
      return json.decode(response.body.toString());
    } else {
      return null;
    }
  }

  static Future<dynamic> put(String route, int id, String body) async {
    // ignore: prefer_interpolation_to_compose_strings
    String baseUrl = baseRoute + route + "/" + id.toString();

    final String basicAuth =
        // ignore: prefer_interpolation_to_compose_strings
        'Basic ' + base64Encode(utf8.encode('$username:$password'));

    final response = await http.put(
      Uri.parse(baseUrl),
      headers: {
        HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
        HttpHeaders.authorizationHeader: basicAuth
      },
      body: body,
    );

    // ignore: avoid_print, prefer_interpolation_to_compose_strings
    print('Status code [PUT] -> ' + response.statusCode.toString());

    if (response.statusCode == 200) {
      return json.decode(response.body.toString());
    } else {
      return null;
    }
  }
  
   static Future<bool> updateKorisnik(int id, Korisnik updatedKorisnik) async {
  // ignore: prefer_interpolation_to_compose_strings
  String baseUrl = baseRoute + "Korisnici/" + id.toString();

  final String basicAuth =
      // ignore: prefer_interpolation_to_compose_strings
      'Basic ' + base64Encode(utf8.encode('$username:$password'));

  final response = await http.put(
    Uri.parse(baseUrl),
    headers: {
      HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
      HttpHeaders.authorizationHeader: basicAuth
    },
    body: json.encode(updatedKorisnik.toJson()),
  );

  if (response.statusCode == 200) {
    return true;
  }

  return false;
}

}
