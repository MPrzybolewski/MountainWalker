using System.Collections.Generic;
using MountainWalker.Core.Models;
using MountainWalker.Core.Interfaces;
using Newtonsoft.Json;
using Plugin.SecureStorage;

namespace MountainWalker.Core.Services
{
    public class TrailService : ITrailService
    {
        public List<Point> Points { get; set; }
        public List<Trail> Trails { get; set; }
        public List<Point> Tops { get; set; }

        public TrailService()
        {
            Points = new List<Point>();
            ReadAllPoints();

            Trails = new List<Trail>();
            CreateConnections();

            Tops = new List<Point>();
            SetTops();
            
        }

        private void ReadAllPoints()
        {
            Points.Add(new Point(54.400680, 18.576661, "skm")); //skm
            Points.Add(new Point(54.400810, 18.574563, "grunwaldzka")); //grunwaldzka
            Points.Add(new Point(54.397705, 18.577010, "przejscie")); //przejscie
            Points.Add(new Point(54.396158, 18.573407, "Mfi")); //Mfi kckckc
            Points.Add(new Point(54.394345, 18.579970, "KFC")); //KFC
            Points.Add(new Point(54.394121, 18.569394, "Ygrek")); //Ygrek <3
            Points.Add(new Point(54.034417, 19.033257, "Malbork")); //Malbork

            Points.Add(new Point(54.090550, 18.790999, "Misiu")); //xvoxin house
            Points.Add(new Point(54.416570, 18.594687, "Lecha Kaczyńskiego xd"));
            Points.Add(new Point(54.493148, 18.539386, "Jit Solution"));

            Points.Add(new Point(49.2681913, 19.9795644, "Start na Kasprowy Wierch")); // 49.26819, 19.97956
            Points.Add(new Point(49.232748, 19.982517, "Kolejka Linowa")); // 49,23274, 19,98251
            Points.Add(new Point(49.26898809999999, 19.9814669)); //49,26899, 19,98147
            Points.Add(new Point(49.25490910000001, 20.0032872, "Przełęcz między Kopami")); //49,25491, 20,00329
            Points.Add(new Point(49.244899,20.006396, "Królowe Rówieńki")); //49,24491, 20,00639
            Points.Add(new Point(49.2440323, 20.0061047));
            Points.Add(new Point(49.2414482, 20.001753));
            Points.Add(new Point(49.237148, 19.996585)); // zolty
            Points.Add(new Point(49.234299, 19.993670));
            Points.Add(new Point(49.231151, 19.982782)); //nadal zolty
            Points.Add(new Point(49.234301, 19.993673));
            Points.Add(new Point(49.232764, 19.982563)); //koniec na kasprowym
        }

        private void SetTops()
        {
            Tops.Add(new Point(0, 49.250996, 19.934021));
            Tops.Add(new Point(1, 49.232294, 19.981717));
            Tops.Add(new Point(2, 49.1798416, 20.0880484));
            Tops.Add(new Point(3, 49.2505826, 19.9317057));
            Tops.Add(new Point(4, 49.2365569, 19.9299811));
            Tops.Add(new Point(5, 49.2194068, 20.0005269));
            Tops.Add(new Point(6, 49.2253989, 20.0058191));
            Tops.Add(new Point(7, 49.1924991, 20.0462452));
            Tops.Add(new Point(8, 49.2184108, 20.0201461));
            Tops.Add(new Point(9, 49.2647705, 19.9401976));
            Tops.Add(new Point(10, 49.2597213, 20.069023));
        }

        private void CreateConnections()
        {
            int id = 1;
            //////////////////////// Test Trail ////////////////////////
            Trails.Add(new Trail());
            Trails[0].Color = "blue";
            Trails[0].Id = 190;
            Trails[0].ShortDescription = "Legendarna droga z SKM na UG";
            Trails[0].Name = "Dolina Alchemii";
            Trails[0].TimeUp = 5;
            Trails[0].TimeDown = 5;
            //Trails[0].PolylineCode = "";
            Trails[0].Path.Add(new Point(54.400647, 18.576544));
            Trails[0].Path.Add(new Point(54.400528, 18.576064));
            Trails[0].Path.Add(new Point(54.400712, 18.575901));
            Trails[0].Path.Add(new Point(54.400772, 18.575757));
            Trails[0].Path.Add(new Point(54.400763, 18.575352));
            Trails[0].Path.Add(new Point(54.401061, 18.575101));
            Trails[0].Path.Add(new Point(54.400818, 18.574548));
            Trails[0].Path.Add(new Point(54.400810, 18.574563));
            Trails[0].Path.Add(new Point(54.399849, 18.575161));
            Trails[0].Path.Add(new Point(54.399249, 18.575701));
            Trails[0].Path.Add(new Point(54.397705, 18.577010));
            Trails[0].Path.Add(new Point(54.397800, 18.576788));
            Trails[0].Path.Add(new Point(54.397216, 18.575113));
            Trails[0].Path.Add(new Point(54.396893, 18.575427));
            Trails[0].Path.Add(new Point(54.396567, 18.574493));
            Trails[0].Path.Add(new Point(54.396324, 18.573653));
            Trails[0].Path.Add(new Point(54.396269, 18.573682));
            Trails[0].Path.Add(new Point(54.396157, 18.573419));
            Trails[0].Path.Add(new Point(54.396110, 18.573478));

            //////////////////////// Road to Kfc will be second trail :D

            Trails.Add(new Trail());
            Trails[1].Color = "red";
            Trails[1].Id = 191;
            Trails[1].ShortDescription = "Co poniedziałek biedni studenci podróżują w to miejsce w poszukiwaniu jedzienia";
            Trails[1].Name = "Burgerogrzmoty KFC";
            Trails[1].TimeUp = 5;
            Trails[1].TimeDown = 5;
            //Trails[1].PolylineCode = "";
            Trails[1].Path.Add(new Point(54.396567, 18.574493));
            Trails[1].Path.Add(new Point(54.396234, 18.576797));
            Trails[1].Path.Add(new Point(54.396250, 18.576855));
            Trails[1].Path.Add(new Point(54.395049, 18.578130));
            Trails[1].Path.Add(new Point(54.395168, 18.578796));
            Trails[1].Path.Add(new Point(54.395168, 18.578796));
            Trails[1].Path.Add(new Point(54.394951, 18.579512));
            Trails[1].Path.Add(new Point(54.394851, 18.579476));
            Trails[1].Path.Add(new Point(54.394427, 18.580052));
            Trails[1].Path.Add(new Point(54.394339, 18.579982));

            ///////////////////////// Now Finaly road to Ygrek!

            Trails.Add(new Trail());
            Trails[2].Color = "green";
            Trails[2].Id = 192;
            Trails[2].ShortDescription = "Po długiej i bolesnej pracy nad projektami, biedni studenci udają się tutaj na piwko";
            Trails[2].Name = "Piwne Oko";
            Trails[2].TimeUp = 5;
            Trails[2].TimeDown = 10;
            //Trails[2].PolylineCode = "";
            Trails[2].Path.Add(new Point(54.396157, 18.573419));
            Trails[2].Path.Add(new Point(54.396257, 18.573158));
            Trails[2].Path.Add(new Point(54.396260, 18.573036));
            Trails[2].Path.Add(new Point(54.396334, 18.572951));
            Trails[2].Path.Add(new Point(54.396069, 18.572149));
            Trails[2].Path.Add(new Point(54.395930, 18.571766));
            Trails[2].Path.Add(new Point(54.395803, 18.571331));
            Trails[2].Path.Add(new Point(54.395861, 18.571273));
            Trails[2].Path.Add(new Point(54.395916, 18.570889));
            Trails[2].Path.Add(new Point(54.395916, 18.570889));
            Trails[2].Path.Add(new Point(54.394995, 18.569080));
            Trails[2].Path.Add(new Point(54.394840, 18.569100));
            Trails[2].Path.Add(new Point(54.394840, 18.569100));
            Trails[2].Path.Add(new Point(54.394563, 18.569352));
            Trails[2].Path.Add(new Point(54.394362, 18.569519));
            Trails[2].Path.Add(new Point(54.393983, 18.569646));

            Trails.Add(new Trail()
            {
                Color = "green",
                Id = id++,
                ShortDescription = "Prosty szlak na Kasprowy Wierch",
                Description = "Trasa na Kasprowy Wierch z Kuźnic należy do jednych z najłatwiejszych w polskich Tatrach. " +
                    "Jest monotonna i chwilami wręcz nudna, wszelako polecam ją z uwagi na brak dużego zatłoczenia szczególnie w " +
                    "okresie zimowym (duża część ludzi po prostu wjeżdża kolejką na szczyt). " +
                    "Ponadto stanowi wspaniałe miejsce do treningu dla biegaczy.",
                Name = "Kasprowy Wierch przez Myślenickie Turnie",
                TimeUp = 150,
                TimeDown = 130,
                Distance = 7.5,
                Image = "kasprowy",
                PolylineCode = new List<string>()
                {
                    "euukHgg}xBpBl@tAV`@XNTPb@Tl@d@^@@HJ^d@n@v@l@x@f@v@`@h@RNHLJFHBD@N?j@DH?HADCNMHIFCDAD?H?F@RBTFbAr@RRdAl@VLxAp@TP\\ZFLDL@PDRD\\?RDZP`@JXNXTb@n@dAXd@VNXFTD`@L\\BnAFv@F^D@?B@DAH?DADCFCBCFEDEHEFCHENGHEFEFERSHKHEDEHCHCHCNIHGLIFEFEDEBGDKBEFMDKJYFIFIDGJQHKFIFGFGFGFEHEFEHEJOLMLKl@q@VYd@i@d@s@HMHIJGFAH@NBN@b@DJBJDHDF@J?FAHAJEDCFADCDAFAFAH?L@H@J?F@H?J?FCJAHEFCJEJEJEDADADAF?BADADADAB?D?F?DB@@@@?@?B?D?FAH?JAN?L?H@B?B@D@@@@@BH@lBZFDJFFFFHJDH@F?HCJEHCPCPCj@ALAPEDEDGBGDKHOf@m@XYLYNWFODSDO@O@M?K?M?M@MDODWDK@KBOBMDMLe@FMDMDGHMFIDKN]Xw@Pg@Lc@Z}@FSPYLUPSLKJGJGZQROJEJELAF?F@D@HFB@DDFBDDDBDDFBFBFDFBF@DBDBDDDDDFFDDBFBFDDBFBDDDBDDBBBD@FBHBJDJBJDJBH@J?H@FAF?JCFCPCLAFAFADCFMTUTm@h@WPIHGDMLKHC?EBC@C?E@E?EAE?E@E?GBE?GBE@GBEBKHEBC@E@C@EBCDA@ADCL?H?J?N?J?P?NALALENALCNARARCNENERQ~@APCPEPEPGRK`@I\\Uj@Sf@ELEJGPGTABADABADAB?B?F@JDVBL@FBFB@@@B?B?DABA@ABE@CBEBC@EBEDG@EBADABABABCBCBADGBABC@CBC@CBABC@ABC@E@CDIBGBIBCBEBE@CBC@EBA@CDGDE@CBC@C@C@E@E@E@C@E@C@C@E?E@E@E?E?E@G@IBE@CBABC@ADCBCBCBEFGJKFCFGFGDEDEDIDEFEFCFAFANGPEJALAJ?H?N@n@@N?REXOLIJGLC`@KT?TDPHPHRDT?PCT?P?L?NDPFLFNFLBJFLDjAHX?NAR?B?BCFEDCFAF?D@FDNTJJDDNVVd@LLDH@@@@@?@??A@A?A?OAMBSDe@BO@E?A@A@A@?@?@@BDFLHJFHHNJHLLLDLBJAJEFCBC@?@A?A?A?A?A?AGICMAEAG?E?K?M?K?C?C@C@A@?@?@@@DDBDBFBL@H@J?H?HAH?JAJCHAJCHAHCFGBC?A?A?A?AAAECCCCCECCEEECEAA?C?CAA@C?C@CXGZONIJKJGHAb@ENELGNANBNFJJJNNVH\\HPHJPTRP^Pl@XPHNJDDNDl@DT?LCJCZOb@MHCFCHIHMR_@JQZWp@m@b@[FCBCBCBIBIDGDA@A?A@C?A?CAGCGAC?C?E?QBEBI@?FCB@HBFBB@B?HBD@D@D@@@B@@DFNDLDJFHPZLNTPDDFDBDBDBDJHJDHB@@B@@@@@@@B@@@@@B?@@@?@?B@@@@@@B@@@B@B@@@@BFBFHHBDB@@?B?@?BABABA@CBC?C@C?E?C?C?AAE?AA??AAACACACCACCC?CAG?EACAGAC?ACAAACAC?A?A?CAICGGIOIUOg@CQKi@AE?C?A@??A?A@?B?@?BBBBBFBH@H@D@D@BHJHFHFHFDBF@HBB?BABADAJGLEDAB?B?@@B?@@B@?B@@@B@@@@BDB@?@@?@?@?@ABA@A@AHIPWVc@HQDI@A@CBA@C@C@A?A@?@A@@@@@B@B@D@B@DBDDFDDLLVTNL@@@?@?@??A?A?A?AAA?AAAAECMQy@Oq@COAGACAE?E?G?G?E@C@ABCBABA@A@A?C@O?C@C@A@?@?@?@@@@?@BF?F@H@D?D@HBJ@D?B@@@DBLDHBBBBBBBBB@BB@@B@@BBF?@@@@@@@@?B?B?BAB?BABALCBADAFCJEFAFCB?BAD?B?B?B?D?B?B?D?B?JA@A@??A?A?A?AAAAAKAECICKGKGAAECACCAAAECAECCCGEQAE?GAGAC?CAECIEY?A?A?A?A@A@?@?BBDB@@@?@@B@@?@@?@@??@@D?D?D@??@@@@@@@BB@@@B@B@B@B@B?@@?@?@@B?F?j@BT?D?B?F@B?LBP@`@?R@F?@?@A@A?A?A?ACCIC]YKOKSUe@KUIKEKACAGAE?EAE?E?M?I?G@C?A@?@??@@@BD@@@?@@@?@?BCB?BA@?@@@??@?@@@@BBB@@BDB@@B@@B@DBD?B@D@B?B?B?B?BAD?HC`@KTGFCDC@A?A@A?A?A?AAA?AA?CCCAAAAC?CAA?E?C?C@C@E@C@CBA?A@?BAB?BAFABADCBAFABABAB?LCVEFEHEHEJGJGHGJEFEFCHCPE`@Gf@MPE\\IJGHCFCF?F?FAlAM",
                    "iwnkH_n}xBEqA@E@C@C@A@A@AB?@A@?@A@?BC@A@A@A@A@A@A@?@A@A@A@?@A?A?A?CAA?GAA?E?A@C?C@C@A@C@A@C@C@ABC@I?KAE?MCIEOQYWk@ISEKCK"
                }
            });
            
            Trails.Add(new Trail()
            {
                Color = "yellow",
                Id = id++,
                ShortDescription = "Jakis na Hale heh",
                Name = "Szlak pieszy żółty",
                TimeUp = 65,
                TimeDown = 65,
                PolylineCode = new List<string>()
                {
                    "ezukHes}xBPDHDTPPLJFRJD@BADABABEFINQFEFCDAF?L@`Ad@j@\\d@\\NBLBR@TAX?NBVDZTTLH@J@J@FAHAFC\\a@f@s@V[NQFGNKTM\\Ul@[ZQ^QXMVM\\WRSNGVIZM^OPKNMHGHMLYTm@L[P[Tc@Pa@FUHUFWBUBMBGBGDIJKNIFGDKFSDQ@Q?M@E?C?A@E@A@EBC@ADCPKNOPKJIJEREPIDCBABAFIPWPMFCBCBA@EDKJ]HQHUV_@V_@Ta@P_@L]P_@HWFWDOBMBE@EDGT]j@gAHQNa@Pi@f@gAP]HMHOHEDEDGJMFKJUp@y@NQZa@Tc@DOBIDGJMDSDG@E@EBUJs@De@@W?_@@O@O@QHi@Fm@DYD_@F]XwA`@aBH_@BQBODo@Hs@BS@G@A@A@A@?@?@??@@?@D@DBFDRBNFTBR@LBt@Bd@DZF^DL@BB?B@D?HCHANAZGXGPKJITQdAm@ZO\\MHCLCTCZIdAc@t@WZKLEJG^]FG@CBC@E?A?A?A?A?AA??AA?AAA?K?ICEA[Sm@m@[_@KSACKGGGCCAC?AAC?A?C@G@EDIDGPQJQPMNINKFIFML[DSFWDS?M?_CAiAEq@Ei@Ca@CYCWCSCOEGKKKKGKKQAICKCG?IAK?O@MJo@Ji@Fe@D[@I@g@@m@@IFa@@KFWJo@H[BS@I@I?C?C?A?AEKEGUo@O[GOQUMIOKMIGCAAACAC?C?WASAG?E@U"
                }
            });
            
            Trails.Add(new Trail()
            {
                Color = "blue",
                Id = id++,
                ShortDescription = "Piękne widoczki na Hale",
                Name = "Dolina Gąsienicowa",
                TimeUp = 18,
                TimeDown = 15,
                PolylineCode = new List<string>()
                {
                    "ucqkH}nbyBGFCDABC@A@C?E?E?o@KMAQG]WMGKEKAc@GYAGAGAKGYOSIg@UQKQS_@_@a@[i@[_@Yc@UOESAe@ASBQ@OBK@OAU?MBIFIHSVGPGHEBMDMDKHUDUFO@]?Q@WDYDa@@e@Di@Hm@@e@D_@H[JUJ[TQP[f@i@hAk@bAY\\m@p@OJUDWHk@P[NUJUHYHODOFQNQRMZIXO^_@r@i@p@UVc@b@SL"
                }
            });
            
            Trails.Add(new Trail()
            {
                Color = "blue",
                Id = id++,
                ShortDescription = "Z Hali do Suchej",
                Name = "Szlak pieszy niebieski",
                TimeUp = 1,
                TimeDown = 1,
                PolylineCode = new List<string>()
                {
                    "ucqkH}nbyBB?D@DAB?D?JBJFDBL@NCL@LBXNTJDDFB"
                }
            });
            
            Trails.Add(new Trail()
            {
                Color = "black",
                Id = id++,
                ShortDescription = "nie wiem co to heh",
                Name = "Szlak pieszy czarny",
                TimeUp = 5,
                TimeDown = 5,
                PolylineCode = new List<string>()
                {
                    "anpkH}qayBECCACCAACCAACCACAAAACACAGCCACAAACAAC?CAIACAEACAGAECCIOGKEICGGOIWGOIWCGEIKQGKEGEMM]IUKWOQOOEEQIKIEEEES]]g@[g@[c@OSEIGKEIGMGQGQCQEc@ASAYAO?GCGCGEIIMAAAAAC?CAE"
                }
            });
            
            Trails.Add(new Trail()
            {
                Color = "black",
                Id = id++,
                ShortDescription = "kolejny czarnuch",
                Name = "Szlak pieszy czarny",
                TimeUp = 11,
                TimeDown = 9,
                PolylineCode = new List<string>()
                {
                    "anpkH}qayBNVT\\JVLTJPV`@DJ@DDDFJHJJLDDPVHJBDHFDFHFBFBB@B@BB@@@B@@@@@@B@@@BB@@BB@@@B@@BBB@@@@DFLRHJNRHJVRJLHFFFHFDHLRJLNTX\\NXFHNTFJDHDJHRDNTZBFBD@HBHBJBL@DBDBFB@B@B@@@B@@BB@@@@@@B@B@@B@@@B@@@B@B@DDFHBFDFFFDDNLNHZVZZZXPPBD@@B@B@@@B?F?B?@?DABA"
                }
            });

            Trails.Add(new Trail()
            {
                Color = "yellow",
                Id = id++,
                ShortDescription = "witam Cie",
                Name = "Szlak pieszy żółty",
                TimeUp = 0,
                TimeDown = 0,
                PolylineCode = new List<string>
                {
                    "asokHwq`yBLBNHPJTRHFTNJJLLBBBFHNBD@BFH@BDF@B@B@B@D?@@DFJ@@BB@DBBHFDD@BBB@@@B@B@@BFBFHHFJBFB@@B@B@D@B@B@B@B@B@B@B@B@D@B@B@DBD@@@BBBH@@?@?N?F?D@@@B@@@B@B@@?B?BAB?B?B@@@DBD@DFPLHFFFLPRXLTJLJNLNHH\\Z"
                }
            });

            Trails.Add(new Trail()
            {
                Color = "yellow",
                Id = id++,
                ShortDescription = "Do zmany, wiesz",
                Name = "Szlak pieszy żółty",
                TimeUp = 0,
                TimeDown = 0,
                PolylineCode = new List<string>
                {
                    "smnkHk{}xBf@oA",
                    "klnkH{}}xBPmALu@LeAFu@@M?M?IAu@G}@Ck@EWGe@ESESIUIUIUq@uAg@cASk@Yk@Ya@a@i@k@y@SWOKYKMGMIEEGKIQiAkCq@eB[w@_@eAQe@Om@GUCWMu@Mq@YmAO{@Ki@AKAGAGAEAEACAEACAECC?CACAEACAE?G@E@E?CBG@E@E@E@E@G?EBE@E@CBEHe@"
                }
            });

            Trails.Add(new Trail()
            {
                Color = "green",
                Id = id++,
                ShortDescription = "No to juz kasprowy xd",
                Name = "Kasprowy",
                TimeUp = 0,
                TimeDown = 0,
                PolylineCode = new List<string>
                {
                    "wwnkH_z}xB?A?A@?@?RC@ABA@C@AB?B?D@x@Vj@FD@H?t@M^KHA\\QDCXK"
                }
            });
        }
    }
}