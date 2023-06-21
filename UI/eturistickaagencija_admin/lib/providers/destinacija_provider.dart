import 'dart:convert';
import 'package:eturistickaagencija_admin/providers/base_provider.dart';

import '../models/destinacija.dart';



class DestinacijaProvider extends BaseProvider<Destinacija>{
  DestinacijaProvider():super("Destinacije");

  @override
  Destinacija fromJson(data) {
    // TODO: implement fromJson
    return Destinacija.fromJson(data);
  }

}