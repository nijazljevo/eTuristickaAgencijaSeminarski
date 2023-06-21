// import 'dart:convert';
// import 'package:flutter/material.dart';
// import 'package:http/http.dart' as http;

// class TerminiScreen extends StatefulWidget {
//   @override
//   _TerminiScreenState createState() => _TerminiScreenState();
// }

// class _TerminiScreenState extends State<TerminiScreen> {
//   Future<Termin?>? _futureTermin;
//   Termin? _termin;

//   @override
//   void initState() {
//     super.initState();
//     _futureTermin = fetchTermin();
//   }

//   Future<Termin?> fetchTermin() async {
//     final url = 'http://localhost:5011/api/Termini/1';
//     final response = await http.get(Uri.parse(url));

//     if (response.statusCode == 200) {
//       final dynamic responseData = json.decode(response.body);
//       _termin = Termin(id: responseData['id']);
//       return _termin;
//     } else {
//       throw Exception('Failed to fetch termin');
//     }
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       appBar: AppBar(
//         title: Text('Termini'),
//       ),
//       body: FutureBuilder<Termin?>(
//         future: _futureTermin,
//         builder: (context, snapshot) {
//           if (snapshot.connectionState == ConnectionState.waiting) {
//             return Center(child: CircularProgressIndicator());
//           } else if (snapshot.hasError) {
//             return Center(child: Text('Error: ${snapshot.error}'));
//           } else if (snapshot.hasData && _termin != null) {
//             return Center(child: Text('Termin ID: ${_termin!.id}'));
//           } else {
//             return Center(child: Text('No termin found'));
//           }
//         },
//       ),
//     );
//   }
// }

// class Termin {
//   final int id;

//   Termin({required this.id});
// }

import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class TerminiScreen extends StatefulWidget {
  @override
  _TerminiScreenState createState() => _TerminiScreenState();
}

class _TerminiScreenState extends State<TerminiScreen> {
  Future<List<Termin>>? _futureTermini;
  List<Termin> _termini = [];

  @override
  void initState() {
    super.initState();
    _futureTermini = fetchTermini();
  }

  Future<List<Termin>> fetchTermini() async {
    final url = 'http://localhost:5011/api/Termini';
    final response = await http.get(Uri.parse(url));

    if (response.statusCode == 200) {
      final dynamic responseData = json.decode(response.body);
      final termini = responseData.map<Termin>((data) => Termin(
            id: data['id'],
            destinacija: data['destinacija'],
            cijena: data['cijena'].toDouble(),
            datumPolaska: DateTime.parse(data['datumPolaska']),
            datumDolaska: DateTime.parse(data['datumDolaska']),
            aktivan: data['aktivan'],
          )).toList();

      return termini;
    } else {
      throw Exception('Failed to fetch termini');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Termini'),
      ),
      body: FutureBuilder<List<Termin>>(
        future: _futureTermini,
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(child: CircularProgressIndicator());
          } else if (snapshot.hasError) {
            return Center(child: Text('Error: ${snapshot.error}'));
          } else if (snapshot.hasData && _termini.isNotEmpty) {
            _termini = snapshot.data!; // Dodajte ovu liniju kako biste ažurirali listu _termini

            return ListView.builder(
              itemCount: _termini.length,
              itemBuilder: (context, index) {
                final termin = _termini[index];
                return ListTile(
                  title: Text('Termin ID: ${termin.id}'),
                  subtitle: Text('Destinacija: ${termin.destinacija}'),
                );
              },
            );
          } else {
            return Center(child: Text('No termini found'));
          }
        },
      ),
    );
  }
}

class Termin {
  final int id;
  final String destinacija;
  final double cijena;
  final DateTime datumPolaska;
  final DateTime datumDolaska;
  final bool aktivan;

  Termin({
    required this.id,
    required this.destinacija,
    required this.cijena,
    required this.datumPolaska,
    required this.datumDolaska,
    required this.aktivan,
  });
}


