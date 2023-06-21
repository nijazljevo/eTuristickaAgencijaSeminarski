import 'dart:convert';
import 'dart:io';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:image_picker/image_picker.dart';
import '../models/grad.dart';
import '../models/hotel.dart';

class Hotel1 {
  final int id;
  final String naziv;
  final int gradId;
  final int brojZvjezdica;
  final String slika;

  Hotel1({
    required this.id,
    required this.naziv,
    required this.gradId,
    required this.brojZvjezdica,
    required this.slika,
  });

  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'naziv': naziv,
      'gradId': gradId,
      'brojZvjezdica': brojZvjezdica,
      'slika': slika,
    };
  }
}

class HotelDetailsScreen extends StatefulWidget {
  final Hotel? hotel;

  const HotelDetailsScreen({Key? key, this.hotel}) : super(key: key);

  @override
  _HotelDetailsScreenState createState() => _HotelDetailsScreenState();
}

class _HotelDetailsScreenState extends State<HotelDetailsScreen> {
  final _formKey = GlobalKey<FormState>();
  late TextEditingController _nazivController;
  late TextEditingController _brojZvjezdicaController;
  List<Grad> grad = [];
  Grad? selectedGrad;
  File? selectedImage;
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    fetchGradovi();
    _nazivController = TextEditingController();
    _brojZvjezdicaController = TextEditingController();
    if (widget.hotel != null) {
      _nazivController.text = widget.hotel!.naziv!;
      _brojZvjezdicaController.text = widget.hotel!.brojZvjezdica.toString();
    }
  }

  Future<void> fetchGradovi() async {
    int kontinentId = 0;
    int drzavaId = 0; // Set the desired values for drzavaId and kontinentId

    try {
      final url =
          'http://localhost:5011/api/Gradovi?drzavaId=$drzavaId&kontinentId=$kontinentId';
      final response = await http.get(Uri.parse(url));

      if (response.statusCode == 200) {
        final List<dynamic> responseData = json.decode(response.body);
        grad = responseData.map((data) {
          return Grad(
            id: data['id'],
            naziv: data['naziv'],
          );
        }).toList();
      } else {
        throw Exception('Failed to fetch gradovi');
      }
    } catch (error) {
      print(error);
    }

    setState(() {});
  }

  Future<void> addHotel(Hotel1 noviHotel) async {
    final response = await http.post(
      Uri.parse('http://localhost:5011/api/Hoteli'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode(noviHotel.toJson()),
    );

    if (response.statusCode == 200) {
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text('Success'),
            content: Text('Hotel added successfully.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: Text('OK'),
              ),
            ],
          );
        },
      );
    } else {
      print('Error: ${response.statusCode}');
      print('Response body: ${response.body}');

      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text('Error'),
            content: Text('Failed to add hotel.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: Text('OK'),
              ),
            ],
          );
        },
      );
    }
  }

  Future<void> editHotel(Hotel1 hotel) async {
    final updatedHotel = Hotel1(
      id: hotel.id,
      naziv: hotel.naziv,
      gradId: hotel.gradId,
      brojZvjezdica: hotel.brojZvjezdica,
      slika: hotel.slika,
    );

    final response = await http.put(
      Uri.parse('http://localhost:5011/api/Hoteli/${hotel.id}'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode(updatedHotel.toJson()),
    );

    print('Response status code: ${response.statusCode}');
    print('Response body: ${response.body}');

    if (response.statusCode == 200) {
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text('Success'),
            content: Text('Hotel updated successfully.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: Text('OK'),
              ),
            ],
          );
        },
      );
    } else {
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text('Error'),
            content: Text('Failed to update hotel.'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: Text('OK'),
              ),
            ],
          );
        },
      );
    }
  }

  Future<void> pickImage() async {
    final pickedImage = await ImagePicker().getImage(source: ImageSource.gallery);
    if (pickedImage != null) {
      setState(() {
        selectedImage = File(pickedImage.path);
      });
    }
  }

  void _submitForm() {
    if (_formKey.currentState!.validate()) {
      final String naziv = _nazivController.text;
      final int brojZvjezdica = int.parse(_brojZvjezdicaController.text);

      final Hotel1 noviHotel = Hotel1(
        id: widget.hotel?.id ?? 0,
        naziv: naziv,
        gradId: selectedGrad!.id,
        brojZvjezdica: brojZvjezdica,
        slika: selectedImage != null ? base64Encode(selectedImage!.readAsBytesSync()) : '',
      );

      if (widget.hotel != null) {
        editHotel(noviHotel);
      } else {
        addHotel(noviHotel);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Dodaj hotel'),
      ),
      body: Padding(
        padding: EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: Column(
            children: [
              TextFormField(
                controller: _nazivController,
                decoration: InputDecoration(labelText: 'Naziv hotela'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Molimo unesite naziv hotela.';
                  }
                  return null;
                },
              ),
              DropdownButtonFormField<Grad>(
                value: selectedGrad,
                hint: Text('Odaberite grad'),
                items: grad.map((grad) {
                  return DropdownMenuItem<Grad>(
                    value: grad,
                    child: Text(grad.naziv),
                  );
                }).toList(),
                onChanged: (Grad? value) {
                  setState(() {
                    selectedGrad = value;
                  });
                },
                validator: (value) {
                  if (value == null) {
                    return 'Molimo odaberite grad.';
                  }
                  return null;
                },
              ),
              TextFormField(
                controller: _brojZvjezdicaController,
                keyboardType: TextInputType.number,
                decoration: InputDecoration(labelText: 'Broj zvjezdica'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Molimo unesite broj zvjezdica.';
                  }
                  if (int.tryParse(value) == null) {
                    return 'Molimo unesite valjani broj.';
                  }
                  return null;
                },
              ),
              SizedBox(height: 16.0),
              ElevatedButton(
                onPressed: pickImage,
                child: Text('Odaberite sliku'),
              ),
              SizedBox(height: 16.0),
              ElevatedButton(
                onPressed: _submitForm,
                child: Text('Spremi'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}


class Grad {
  final int id;
  final String naziv;

  Grad({
    required this.id,
    required this.naziv,
  });
}

class Drzava {
  final int id;
  final String naziv;

  Drzava({
    required this.id,
    required this.naziv,
  });
}

class Kontinent1 {
  final int id;
  final String naziv;

  Kontinent1({
    required this.id,
    required this.naziv,
  });
}
