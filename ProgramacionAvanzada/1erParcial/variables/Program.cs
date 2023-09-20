WriteLine("----------------------------------------------------------------------------");//separaciones para dar mas orden
WriteLine($"{"Type",-8} {"Byte(s) of memory",-17} {"Min",17} {"Max",31}"); //Nombre de las columnas
WriteLine("----------------------------------------------------------------------------");
WriteLine($"{"sbyte",-8} {sizeof(sbyte),-3} {sbyte.MinValue,31} {sbyte.MaxValue,31}"); //mostramos el nombre del valor asi como cuantos bytes ocupa, su valor minimo y maximo
WriteLine($"{"byte",-8} {sizeof(byte),-3} {byte.MinValue,31} {byte.MaxValue,31}");
WriteLine($"{"short",-8} {sizeof(short),-3} {short.MinValue,31} {short.MaxValue,31}");
WriteLine($"{"ushort",-8} {sizeof(ushort),-3} {ushort.MinValue,31} {ushort.MaxValue,31}");
WriteLine($"{"int",-8} {sizeof(int),-3} {int.MinValue,31} {int.MaxValue,31}");
WriteLine($"{"uint",-8} {sizeof(uint),-3} {uint.MinValue,31} {uint.MaxValue,31}");
WriteLine($"{"long",-8} {sizeof(long),-3} {long.MinValue,31} {long.MaxValue,31}");
WriteLine($"{"ulong",-8} {sizeof(ulong),-3} {ulong.MinValue,31} {ulong.MaxValue,31}");
WriteLine($"{"float",-8} {sizeof(float),-3} {float.MinValue,31} {float.MaxValue,31}");
WriteLine($"{"double",-8} {sizeof(double),-3} {double.MinValue,31} {double.MaxValue,31}");
WriteLine($"{"decimal",-8}{sizeof(decimal),-3}{decimal.MinValue,33}{decimal.MaxValue,32}");
WriteLine("----------------------------------------------------------------------------"); //fin :)





