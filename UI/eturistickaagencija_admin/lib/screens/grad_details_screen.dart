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

class GradDetailsScreen extends StatefulWidget {
  Grad? grad;
  GradDetailsScreen({Key? key, this.grad}) : super(key: key);

  @override
  State<GradDetailsScreen> createState() => _GradDetailsScreenState();
}

class _GradDetailsScreenState extends State<GradDetailsScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late DrzavaProvider _drzavaProvider;
  late GradProvider _gradProvider;

  SearchResult<Drzava>? drzavaResult;
  bool isLoading = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _initialValue = {
      'naziv': widget.grad?.naziv,
      'drzavaId': widget.grad?.drzavaId?.toString(),
    };

    _drzavaProvider = context.read<DrzavaProvider>();
    _gradProvider = context.read<GradProvider>();

    initForm();
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();

   
  }

  Future initForm() async {
    drzavaResult = await _drzavaProvider.get();
    print(drzavaResult);


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
                        if (widget.grad == null) {
                          await _gradProvider
                              .insert(request);
                        } else {
                          await _gradProvider.update(
                              widget.grad!.id!,
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
      title: this.widget.grad?.naziv ?? "Grad details",
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
              name: 'drzavaId',
              decoration: InputDecoration(
                labelText: 'Drzava',
                suffix: IconButton(
                  icon: const Icon(Icons.close),
                  onPressed: () {
                    _formKey.currentState!.fields['drzavaId']?.reset();
                  },
                ),
                hintText: 'Select Gender',
              ),
              items: drzavaResult?.result
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
        Row(
          children: [
          
          ],
        )
      ]),
    );
  }



  
}
