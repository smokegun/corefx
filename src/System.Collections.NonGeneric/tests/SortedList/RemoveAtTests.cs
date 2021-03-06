// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Text;
using Xunit;

namespace System.Collections.Tests
{
    public class SortedList_RemoveAtTests : IComparer
    {
        public virtual int Compare(object obj1, object obj2)  // ICompare satisfier.
        {
            return string.Compare(obj1.ToString(), obj2.ToString());
        }

        [Fact]
        public void TestRemoveAtBasic()
        {
            StringBuilder sblMsg = new StringBuilder(99);

            SortedList sl2 = null;

            StringBuilder sbl3 = new StringBuilder(99);
            StringBuilder sbl4 = new StringBuilder(99);
            StringBuilder sblWork1 = new StringBuilder(99);

            String s1 = null;
            String s2 = null;

            int i = 0;
            //
            // 	Constructor: Create SortedList using this as IComparer and default settings.
            //
            sl2 = new SortedList(this);

            //  Verify that the SortedList is not null.
            Assert.NotNull(sl2);

            //  Verify that the SortedList is empty.
            Assert.Equal(0, sl2.Count);

            //   Testcase: add few key-val pairs

            for (i = 0; i < 100; i++)
            {
                sblMsg.Length = 0;
                sblMsg.Append("key_");
                sblMsg.Append(i);
                s1 = sblMsg.ToString();

                sblMsg.Length = 0;
                sblMsg.Append("val_");
                sblMsg.Append(i);
                s2 = sblMsg.ToString();

                sl2.Add(s1, s2);
            }

            //  Verify that the SortedList is empty.
            Assert.Equal(100, sl2.Count);

            //
            //   Testcase: test RemoveAt (int index)
            //
            for (i = 0; i < 100; i++)
            {
                sl2.RemoveAt((int)(99 - i)); // remove from the end
                Assert.Equal(sl2.Count, (100 - (i + 1)));
            }

            //
            // Boundary - Remove a invalid key index: -1
            //
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    sl2.RemoveAt(-1);
                }
                );

            //
            // Boundary - Remove a invalid key index: 0
            //
            Assert.Throws<ArgumentOutOfRangeException>(() =>
               {
                   sl2.RemoveAt(0);
               }
               );

            //
            // Boundary - Int32.MaxValue key - expect argexc
            //
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    sl2.RemoveAt(Int32.MaxValue);
                }
                );
        }
    }
}
