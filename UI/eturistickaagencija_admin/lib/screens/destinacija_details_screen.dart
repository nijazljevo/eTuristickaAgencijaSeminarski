import 'dart:convert';
import 'dart:io';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:image_picker/image_picker.dart';

import '../models/grad.dart';
import 'grad_details_screen.dart';


class Destinacija{
  final int id;
  final String naziv;
  final int? gradId;
  final String slika;

  Destinacija({required this.id, required this.naziv, this.gradId,required this.slika});

  Map<String, dynamic> toJson() {
    Map<String, dynamic> json = {
      'id': id,
      'naziv': naziv,
      'gradId': gradId,
      'slika':slika
    };

    return json;
  }
}

class DestinacijaDetailsScreen extends StatefulWidget {
  final Destinacija? destinacija;

  const DestinacijaDetailsScreen({Key? key, this.destinacija}) : super(key: key);
  @override
  _DestinacijaDetailsScreenState createState() =>
      _DestinacijaDetailsScreenState();
}

class _DestinacijaDetailsScreenState extends State<DestinacijaDetailsScreen> {
  final _formKey = GlobalKey<FormState>();
  late TextEditingController _nazivController;
  List<Drzava> drzave = [];
  List<Kontinent> kontinenti = [];
  List<Grad> grad = [];
  Grad? selectedGrad;
  late int _selectedDrzavaId;
  bool isLoading = true;
  File? selectedImage;

  @override
  void initState() {
    super.initState();
    _selectedDrzavaId = -1;
    fetchGradovi();
    _nazivController = TextEditingController();
    if (widget.destinacija != null) {
      _nazivController.text = widget.destinacija!.naziv;
      if (widget.destinacija!.gradId != null) {
        selectedGrad =
            grad.firstWhere((drzava) => drzava.id == widget.destinacija!.gradId);
      }
    }
  }
    @override
  void dispose() {
    _nazivController.dispose();
    super.dispose();
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

 Future<void> addDestination(Destinacija noviGrad) async {
  final response = await http.post(
    Uri.parse('http://localhost:5011/api/Destinacije'),
    headers: {'Content-Type': 'application/json'},
    body: jsonEncode(noviGrad.toJson()),
  );

  if (response.statusCode == 200) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('Success'),
          content: Text('Destination added successfully.'),
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
          content: Text('Failed to add destination.'),
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
 Future<void> editDestination(Destinacija destinacija) async {
    final updatedDestinacija =
        Destinacija(id: destinacija.id, naziv: destinacija.naziv, gradId: destinacija.gradId,slika:destinacija.slika);

    final response = await http.put(
      Uri.parse('http://localhost:5011/api/Destinacije/${destinacija.id}'),
      headers: {'Content-Type': 'application/json'},
      body: jsonEncode(updatedDestinacija.toJson()),
    );

    print('Response status code: ${response.statusCode}');
    print('Response body: ${response.body}');

    if (response.statusCode == 200) {
      showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            title: Text('Success'),
            content: Text('Destination updated successfully.'),
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
            content: Text('Failed to update destination.'),
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
      final String naziv = _nazivController.text.trim();
   
      final Destinacija noviGrad = Destinacija(
        id: widget.destinacija?.id ?? 0,
        naziv: naziv,
        gradId: selectedGrad?.id,
        slika: selectedImage != null ? base64Encode(selectedImage!.readAsBytesSync()) : '',
      );
       if (widget.destinacija != null) {
        editDestination(noviGrad);
      } else {
        addDestination(noviGrad);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Destinacije'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: Form(
              key: _formKey,
              child: Column(
                children: [
                  TextFormField(
                    controller: _nazivController,
                    decoration: InputDecoration(
                      labelText: 'Destination Name',
                    ),
                    validator: (value) {
                      if (value!.isEmpty) {
                        return 'Please enter a destination name.';
                      }
                      return null;
                    },
                  ),
                  SizedBox(height: 16.0),
                  DropdownButton<Grad>(
                    value: selectedGrad,
                    onChanged: (value) {
                      setState(() {
                        selectedGrad = value;
                      });
                    },
                    items: grad.map((grad) {
                      return DropdownMenuItem<Grad>(
                        value: grad,
                        child: Text(grad.naziv),
                      );
                    }).toList(),
                  ),
                    SizedBox(height: 16.0),
              ElevatedButton(
                onPressed: pickImage,
                child: Text('Odaberite sliku'),
              ),
                  SizedBox(height: 16.0),
                  ElevatedButton(
                    onPressed: _submitForm,
                    child: Text('Add Destination'),
                  ),
                ],
              ),
            ),
          ),
        ],
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

class Kontinent {
  final int id;
  final String naziv;

  Kontinent({
    required this.id,
    required this.naziv,
  });
}
