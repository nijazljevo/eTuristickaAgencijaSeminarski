import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class Grad {
  final int id;
  final String naziv;
  final int? drzavaId;

  Grad({required this.id, required this.naziv, this.drzavaId});

  Map<String, dynamic> toJson() {
    Map<String, dynamic> json = {
      'id': id,
      'naziv': naziv,
      'drzavaId': drzavaId,
    };

    return json;
  }
}

class DodavanjeGradaScreen extends StatefulWidget {
  final Grad? grad;

  const DodavanjeGradaScreen({Key? key, this.grad}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _DodavanjeGradaScreenState createState() => _DodavanjeGradaScreenState();
}

class _DodavanjeGradaScreenState extends State<DodavanjeGradaScreen> {
  final _formKey = GlobalKey<FormState>();
  late TextEditingController _nazivController;
  List<Drzava> drzave = [];
  List<Kontinent> kontinenti = [];
  Drzava? selectedDrzava;
  late int _selectedKontinentId;
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    _nazivController = TextEditingController();
    _selectedKontinentId = -1;
    loadKontinenti();
    loadDrzave('', 0);
    if (widget.grad != null) {
      _nazivController.text = widget.grad!.naziv;
      if (widget.grad!.drzavaId != null) {
        selectedDrzava =
            drzave.firstWhere((drzava) => drzava.id == widget.grad!.drzavaId);
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
        _selectedKontinentId =
            (kontinenti.isNotEmpty ? kontinenti.first.id : -1)!;
      } else {
        throw Exception('Failed to fetch kontinenti');
      }
    } catch (error) {
      // ignore: avoid_print
      print(error);
    }

    setState(() {});
  }

  Future<void> loadDrzave(String naziv, int kontinentId) async {
    try {
      final url =
          'http://localhost:5011/api/Drzave?naziv=$naziv&kontinentId=$kontinentId';
      final response = await http.get(Uri.parse(url));

      if (response.statusCode == 200) {
        final List<dynamic> responseData = json.decode(response.body);
        drzave = responseData.map((data) {
          return Drzava(
            id: data['id'],
            naziv: data['naziv'],
          );
        }).toList();
        selectedDrzava = drzave.isNotEmpty ? drzave.first : null;
      } else {
        throw Exception('Failed to fetch drzave');
      }
    } catch (error) {
      // ignore: avoid_print
      print(error);
    }

    setState(() {});
  }

  Future<void> addCity(Grad noviGrad) async {
    final response = await http.post(
      Uri.parse('http://localhost:5011/api/Gradovi'),
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
            content: const Text('City added successfully.'),
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
            content: const Text('Failed to add city.'),
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

  Future<void> editCity(Grad grad) async {
    final updatedGrad =
        Grad(id: grad.id, naziv: grad.naziv, drzavaId: grad.drzavaId);

    final response = await http.put(
      Uri.parse('http://localhost:5011/api/Gradovi/${grad.id}'),
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
            content: const Text('City updated successfully.'),
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
            content: const Text('Failed to update city.'),
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
      final Grad noviGrad = Grad(
        id: widget.grad?.id ?? 0,
        naziv: naziv,
        drzavaId: selectedDrzava?.id,
      );

      if (widget.grad != null) {
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
        title: const Text('Gradovi'),
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
                  labelText: 'City Name',
                ),
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Please enter a city name.';
                  }
                  return null;
                },
              ),
              const SizedBox(height: 16.0),
              DropdownButtonFormField<Drzava>(
                value: selectedDrzava,
                items: drzave.map((drzava) {
                  return DropdownMenuItem<Drzava>(
                    value: drzava,
                    child: Text(drzava.naziv),
                  );
                }).toList(),
                onChanged: (Drzava? value) {
                  setState(() {
                    selectedDrzava = value;
                  });
                },
                decoration: const InputDecoration(
                  labelText: 'Country',
                ),
              ),
              const SizedBox(height: 16.0),
              DropdownButtonFormField<Kontinent>(
                value: kontinenti.isNotEmpty ? kontinenti.first : null,
                items: kontinenti.map((kontinent) {
                  return DropdownMenuItem<Kontinent>(
                    value: kontinent,
                    child: Text(kontinent.naziv),
                  );
                }).toList(),
                onChanged: (Kontinent? value) {
                  setState(() {
                    _selectedKontinentId = value!.id;
                    loadDrzave('', _selectedKontinentId);
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

class Drzava {
  final int id;
  final String naziv;

  Drzava({required this.id, required this.naziv});
}

class Kontinent {
  final int id;
  final String naziv;

  Kontinent({required this.id, required this.naziv});
}
