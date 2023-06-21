import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:intl/intl.dart';

import '../models/karta.dart';
import '../models/termin.dart';

class KartaScreen extends StatefulWidget {
  @override
  _KartaScreenState createState() => _KartaScreenState();
}

class _KartaScreenState extends State<KartaScreen> {
  List<Karta> karta = [];
  List<Termin> termin = [];
  List<Korisnik> korisnik = [];

  String? dateText; // Add a variable to store the entered date text

  @override
  void initState() {
    super.initState();
  }

  Future<void> searchKarte(int terminId, int korisnikId, DateTime? datumKreiranja) async {
    try {
      final url =
          'http://localhost:5011/api/Karte?terminId=$terminId&korisnikId=$korisnikId&datumKreiranja=$datumKreiranja';
      final response = await http.get(Uri.parse(url));

      if (response.statusCode == 200) {
        final List<dynamic> responseData = json.decode(response.body);
        karta = responseData.map((data) {
          DateTime? datumKreiranja = data['datumKreiranja'] != null
              ? DateTime.parse(data['datumKreiranja'])
              : null;
          return Karta(
            id: data['id'],
            datumKreiranja: datumKreiranja ?? DateTime(1900),
          );
        }).toList();
      } else {
        throw Exception('Failed to fetch karta');
      }
    } catch (error) {
      print(error);
    }

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Karte'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
                Expanded(
                  child: TextField(
                    decoration: InputDecoration(
                      labelText: 'Datum',
                    ),
                    onChanged: (value) {
                      // Update the entered date text
                      setState(() {
                        dateText = value;
                      });
                    },
                  ),
                ),
                SizedBox(width: 8),
                DropdownButton<Korisnik>(
                  value: korisnik.isNotEmpty ? korisnik[0] : null,
                  onChanged: (value) {
                    // Handle dropdown value change
                    // You may store the value in a variable and use it for searching
                  },
                  items: korisnik.map((korisnik) {
                    return DropdownMenuItem<Korisnik>(
                      value: korisnik,
                      child: Text(korisnik.ime),
                    );
                  }).toList(),
                ),
                SizedBox(width: 8),
                ElevatedButton(
                  onPressed: () {
                    // Handle search button click
                    // You can use the entered values to search for karte
                    // Declare variables to store the parsed values
                    DateTime? datumKreiranja;
                    int terminId = 0;
                    int korisnikId = 0;

                    // Parse the entered date text
                    if (dateText != null && dateText!.isNotEmpty) {
                      try {
                        datumKreiranja = DateFormat('yyyy-MM-dd').parse(dateText!);
                      } catch (error) {
                        print('Invalid date format');
                      }
                    }

                    searchKarte(terminId, korisnikId, datumKreiranja);
                  },
                  child: Text('Pretraga'),
                ),
              ],
            ),
          ),
          Expanded(
            child: SingleChildScrollView(
              child: DataTable(
                columns: const [
                  DataColumn(label: Text('ID')),
                  DataColumn(label: Text('Datum kreiranja')),
                ],
                rows: karta.map((karta) {
                  return DataRow(cells: [
                    DataCell(Text(karta.id.toString())),
                    DataCell(Text(
                      karta.datumKreiranja != null
                          ? karta.datumKreiranja.toString()
                          : '',
                    )),
                  ]);
                }).toList(),
              ),
            ),
          ),
        ],
      ),
    );
  }
}

class Karta {
  final int id;
  final DateTime? datumKreiranja;

  Karta({
    required this.id,
    required this.datumKreiranja,
  });
}

class Termin {
  final int id;
  final double cijena;

  Termin({
    required this.id,
    required this.cijena,
  });
}

class Korisnik {
  final int id;
  final String ime;

  Korisnik({
    required this.id,
    required this.ime,
  });
}
