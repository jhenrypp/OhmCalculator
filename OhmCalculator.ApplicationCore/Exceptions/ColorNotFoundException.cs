using OhmCalculator.ApplicationCore.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace OhmCalculator.ApplicationCore.Exceptions
{
    public class ColorNotFoundException:Exception
    {
        public ColorNotFoundException(Band band):base($"Invalid color for band {band}")
        {

        }

    }
}
