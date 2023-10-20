import 'dart:convert';
import 'dart:io';

import 'package:eturistickaagencija_admin/models/kontinent.dart';
import 'package:eturistickaagencija_admin/providers/grad.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:http/http.dart' as http;
import 'package:image_picker/image_picker.dart';
import 'package:provider/provider.dart';
import '../models/drzava.dart';
import '../models/grad.dart';
import '../models/hotel.dart';
import '../models/search_result.dart';
import '../providers/drzava_provider.dart';
import '../providers/hotel_provider.dart';
import '../providers/kontinent_provider.dart';
import '../widgets/master_screen.dart';

class DrzavaDetailsScreen extends StatefulWidget {
  Drzava? drzava;
  DrzavaDetailsScreen({Key? key, this.drzava}) : super(key: key);

  @override
  State<DrzavaDetailsScreen> createState() => _DrzavaDetailsScreenState();
}

class _DrzavaDetailsScreenState extends State<DrzavaDetailsScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late KontinentProvider _kontinentProvider;
  late DrzavaProvider _drzavaProvider;

  SearchResult<Kontinent>? kontinentResult;
  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _initialValue = {
      'naziv': widget.drzava?.naziv,
      'kontinentId': widget.drzava?.kontinentId?.toString(),
    };

    _kontinentProvider = context.read<KontinentProvider>();
    _drzavaProvider = context.read<DrzavaProvider>();

    initForm();
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();

   
  }

  Future initForm() async {
    kontinentResult = await _kontinentProvider.get();
    print(kontinentResult);


    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      // ignore: sort_child_properties_last
      child: Column(
        children: [
          isLoading ? Container() : _buildForm(),
          Row(
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
              Padding(
                padding: EdgeInsets.all(10),
                child: ElevatedButton(
                    onPressed: () async {
                      _formKey.currentState?.saveAndValidate();

                      print(_formKey.currentState?.value);
                      print(_formKey.currentState?.value['naziv']);

                      var request = new Map.from(_formKey.currentState!.value);

                     
                      
                      try {
                        if (widget.drzava == null) {
                          await _drzavaProvider
                              .insert(request);
                        } else {
                          await _drzavaProvider.update(
                              widget.drzava!.id!,
                              request);
                        }
                      } on Exception catch (e) {
                        showDialog(
                            context: context,
                            builder: (BuildContext context) => AlertDialog(
                                  title: Text("Error"),
                                  content: Text(e.toString()),
                                  actions: [
                                    TextButton(
                                        onPressed: () => Navigator.pop(context),
                                        child: Text("OK"))
                                  ],
                                ));
                      }
                    },
                    child: Text("Sačuvaj")),
              )
            ],
          )
        ],
      ),
      title: this.widget.drzava?.naziv ?? "Drzava details",
    );
  }

  FormBuilder _buildForm() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Column(children: [
        Row(
          children: [
           
            SizedBox(
              width: 10,
            ),
            Expanded(
              child: FormBuilderTextField(
                decoration: InputDecoration(labelText: "Naziv"),
                name: "naziv",
              ),
            ),
          ],
        ),
        Row(
          children: [
            Expanded(
                child: FormBuilderDropdown<String>(
              name: 'kontinentId',
              decoration: InputDecoration(
                labelText: 'Kontinent',
                suffix: IconButton(
                  icon: const Icon(Icons.close),
                  onPressed: () {
                    _formKey.currentState!.fields['kontinentId']?.reset();
                  },
                ),
                hintText: 'Select Gender',
              ),
              items: kontinentResult?.result
                      .map((item) => DropdownMenuItem(
                            alignment: AlignmentDirectional.center,
                            value: item.id!.toString(),
                            child: Text(item.naziv ?? ""),
                          ))
                      .toList() ??
                  [],
            )),
            SizedBox(
              width: 10,
            ),
          
         
          ],
        ),
       
      ]),
    );
  }



  
}
