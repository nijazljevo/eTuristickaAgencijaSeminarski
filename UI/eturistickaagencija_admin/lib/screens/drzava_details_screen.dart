import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class Drzava {
  final int id;
  final String naziv;
  final int? kontinentId;

  Drzava({required this.id, required this.naziv, this.kontinentId});

  Map<String, dynamic> toJson() {
    Map<String, dynamic> json = {
      'id': id,
      'naziv': naziv,
      'kontinentId': kontinentId,
    };

    return json;
  }
}

class DodavanjeDrzaveScreen extends StatefulWidget {
  final Drzava? drzava;

  const DodavanjeDrzaveScreen({Key? key, this.drzava}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _DodavanjeDrzaveScreenState createState() => _DodavanjeDrzaveScreenState();
}

class _DodavanjeDrzaveScreenState extends State<DodavanjeDrzaveScreen> {
  final _formKey = GlobalKey<FormState>();
  late TextEditingController _nazivController;
  List<Drzava> drzave = [];
  List<Kontinent> kontinenti = [];
  Kontinent? selectedKontinent;

  @override
  void initState() {
    super.initState();
    _nazivController = TextEditingController();
    loadKontinenti();
    if (widget.drzava != null) {
      _nazivController.text = widget.drzava!.naziv;
      if (widget.drzava!.kontinentId != null) {
        selectedKontinent =
            kontinenti.firstWhere((kontinent) => kontinent.id == widget.drzava!.kontinentId);
      }
    }
  }

  @override
  void dispose() {
    _nazivController.dispose();
    super.dispose();
  }

  Future<void> loadKontinenti() async {
    try {
      const url = 'http://localhost:5011/api/Kontinenti';
      final response = await http.get(Uri.parse(url));

      if (response.statusCode == 200) {
        final List<dynamic> responseData = json.decode(response.body);
        kontinenti = responseData.map((data) {
          return Kontinent(
            id: data['id'],
            naziv: data['naziv'],
          );
        }).toList();
      } else {
        throw Exception('Failed to fetch kontinenti');
      }
    } catch (error) {
      // ignore: avoid_print
      print(error);
    }

    setState(() {});
  }

  Future<void> addCity(Drzava noviGrad) async {
    final response = await http.post(
      Uri.parse('http://localhost:5011/api/Drzave'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode(noviGrad.toJson()),
    );

    // ignore: avoid_print
    print('Response status code: ${response.statusCode}');
    // ignore: avoid_print
    print('Response body: ${response.body}');

    if (response.statusCode == 200) {
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Success'),
            content: const Text('Country added successfully.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
    } else {
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Error'),
            content: const Text('Failed to add country.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
    }
  }

  Future<void> editCity(Drzava grad) async {
    final updatedGrad =
        Drzava(id: grad.id, naziv: grad.naziv, kontinentId: grad.kontinentId);

    final response = await http.put(
      Uri.parse('http://localhost:5011/api/Drzave/${grad.id}'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode(updatedGrad.toJson()),
    );

    // ignore: avoid_print
    print('Response status code: ${response.statusCode}');
    // ignore: avoid_print
    print('Response body: ${response.body}');

    if (response.statusCode == 200) {
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Success'),
            content: const Text('Country updated successfully.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
    } else {
      // ignore: use_build_context_synchronously
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: const Text('Error'),
            content: const Text('Failed to update country.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'),
              ),
            ],
          );
        },
      );
    }
  }

  void _submitForm() {
    if (_formKey.currentState!.validate()) {
      final String naziv = _nazivController.text.trim();
      final Drzava noviGrad = Drzava(
        id: widget.drzava?.id ?? 0,
        naziv: naziv,
        kontinentId: selectedKontinent?.id,
      );

      if (widget.drzava != null) {
        editCity(noviGrad);
      } else {
        addCity(noviGrad);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Drzave'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              TextFormField(
                controller: _nazivController,
                decoration: const InputDecoration(
                  labelText: 'Country Name',
                ),
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Please enter a country name.';
                  }
                  return null;
                },
              ),
              const SizedBox(height: 16.0),
              DropdownButtonFormField<Kontinent>(
                value: selectedKontinent,
                items: kontinenti.map((kontinent) {
                  return DropdownMenuItem<Kontinent>(
                    value: kontinent,
                    child: Text(kontinent.naziv),
                  );
                }).toList(),
                onChanged: (Kontinent? value) {
                  setState(() {
                    selectedKontinent = value;
                  });
                },
                decoration: const InputDecoration(
                  labelText: 'Continent',
                ),
              ),
              const SizedBox(height: 16.0),
              ElevatedButton(
                onPressed: _submitForm,
                child: const Text('Save'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

class Kontinent {
  final int id;
  final String naziv;

  Kontinent({required this.id, required this.naziv});
}
