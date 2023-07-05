import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:intl/intl.dart';

class KartaScreen extends StatefulWidget {
  const KartaScreen({super.key});

  @override
  // ignore: library_private_types_in_public_api
  _KartaScreenState createState() => _KartaScreenState();
}

class _KartaScreenState extends State<KartaScreen> {
  List<Karta> karta = [];
  List<Termin> termin = [];
  List<Korisnik> korisnik = [];

  String? dateText; 

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
      // ignore: avoid_print
      print(error);
    }

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Karte'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              children: [
               
                
                const SizedBox(width: 8),
                ElevatedButton(
                  onPressed: () {
                    DateTime? datumKreiranja;
                    int terminId = 0;
                    int korisnikId = 0;
                    if (dateText != null && dateText!.isNotEmpty) {
                      try {
                        datumKreiranja = DateFormat('yyyy-MM-dd').parse(dateText!);
                      } catch (error) {
                        // ignore: avoid_print
                        print('Invalid date format');
                      }
                    }

                    searchKarte(terminId, korisnikId, datumKreiranja);
                  },
                  child: const Text('Pretraga'),
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
