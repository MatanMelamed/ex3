using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ex3.Models {
    public class GeneratorForTests {

        int counter;

        private static GeneratorForTests instane = null;
        public static GeneratorForTests Instance {
            get {
                if (instane == null) {
                    instane = new GeneratorForTests();
                    instane.counter = 1;
                }

                return instane;
            }
        }

        public double[] newPoint {
            get {
                double[] point = new double[2];
                point[0] = 180 - counter * 2 ;
                point[1] = -90 + counter * 1;
                counter++;
                return point;
            }
        }
    }
}