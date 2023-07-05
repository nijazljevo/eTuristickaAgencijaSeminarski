
import 'package:eturistickaagencija_admin/providers/base_provider.dart';


import '../models/hotel.dart';

class HotelProvider extends BaseProvider<Hotel>{
  HotelProvider():super("Hoteli");

  @override
  Hotel fromJson(data) {
    // TODO: implement fromJson
    return Hotel.fromJson(data);
  }
}