//Maya ASCII 2020 scene
//Name: NPC_Limbs.ma
//Last modified: Mon, May 17, 2021 04:59:38 PM
//Codeset: 1252
requires maya "2020";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2020";
fileInfo "version" "2020";
fileInfo "cutIdentifier" "201911140446-42a737a01c";
fileInfo "osv" "Microsoft Windows 10 Technical Preview  (Build 19042)\n";
fileInfo "UUID" "249B6303-41D1-DE15-FDF9-DBA80FAD2928";
fileInfo "license" "student";
createNode transform -s -n "persp";
	rename -uid "685F3F65-4074-62BD-C6B6-768A190CA96E";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 15.200509751737837 6.2640348945896323 4.2946401426377001 ;
	setAttr ".r" -type "double3" -18.338352734211739 74.600000000160975 5.9884794061540459e-15 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "A42F058B-4B41-FAA0-9C7C-25B3CB89FA3D";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 15.772031802991869;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 1.2594494614348664 1.9312952636099894 -1.7881393432617188e-07 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "AFB64371-4BA4-4124-CB03-07B714F2394F";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -90 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "0FBF0C00-47F4-4101-CFD2-41993E612DC2";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	rename -uid "2A6BF41B-4602-5509-7C33-7D8E4FBD010F";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "34835D6E-4616-F420-E1FB-9AA7F4D53980";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	rename -uid "2526CB89-413C-1804-4808-F9B9ECCFE7AB";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 90 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "A6599DD2-468E-1B44-A8A8-AD9D06578B63";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "pCube1";
	rename -uid "26302C69-44E9-1A0C-15FF-6BACA6E1252F";
	setAttr ".t" -type "double3" 0 0 5 ;
	setAttr ".s" -type "double3" 0.53083301073476308 0.53083301073476308 0.53083301073476308 ;
createNode transform -n "polySurface1" -p "pCube1";
	rename -uid "4DCADC8F-4777-57AF-33FF-3B8D7A45CA62";
	setAttr ".t" -type "double3" 0 3.8591687435310038 -13 ;
	setAttr ".s" -type "double3" 0.597716610984662 0.597716610984662 0.597716610984662 ;
	setAttr ".rp" -type "double3" 0.18200104661902783 -0.40753972082599499 -0.074286628617558359 ;
	setAttr ".sp" -type "double3" 0.30449387431144714 -0.68182766437530518 -0.12428402900695801 ;
	setAttr ".spt" -type "double3" -0.1224928276924193 0.27428794354931019 0.049997400389399642 ;
createNode transform -n "transform2" -p "|pCube1|polySurface1";
	rename -uid "613AFF0C-4224-77BA-F2E8-2CB96A4715FC";
	setAttr ".v" no;
createNode mesh -n "polySurfaceShape1" -p "transform2";
	rename -uid "F0410F2D-493E-0550-E98C-9099D3782D5F";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 33 "f[0]" "f[1]" "f[2]" "f[3]" "f[4]" "f[5]" "f[6]" "f[7]" "f[8]" "f[9]" "f[10]" "f[11]" "f[12]" "f[13]" "f[14]" "f[15]" "f[16]" "f[17]" "f[18]" "f[19]" "f[20]" "f[21]" "f[22]" "f[23]" "f[24]" "f[25]" "f[26]" "f[27]" "f[28]" "f[29]" "f[30]" "f[31]" "f[32]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 42 ".uvst[0].uvsp[0:41]" -type "float2" 0.375 0.25 0.625
		 0.25 0.625 0.5 0.375 0.5 0.375 0.5 0.625 0.5 0.625 0.75 0.375 0.75 0.375 0.75 0.625
		 0.75 0.625 1 0.375 1 0.625 0 0.875 0 0.875 0.25 0.125 0 0.375 0 0.125 0.25 0.625
		 0.5 0.375 0.5 0.625 0.5 0.625 0.75 0.625 0.75 0.625 0.5 0.375 0.75 0.625 0.75 0.625
		 0.5 0.375 0.5 0.625 0.75 0.375 0.75 0.625 0.75 0.625 0.5 0.625 0.75 0.625 0.5 0.625
		 0.5 0.625 0.75 0.625 0.75 0.625 0.5 0.625 0 0.375 0 0.625 0.25 0.375 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 36 ".vt[0:35]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 -0.6140852 -1.13321018 0.5 -0.6140852 -1.13321018 -0.5 -1.15576422 -0.29262257
		 0.5 -1.15576422 -0.29262257 -0.64166665 -1.075780511 -1.59926319 0.31783155 -1.075780511 -1.59926319
		 0.31783155 -1.77093565 -0.52051163 -0.64166665 -1.77093565 -0.52051163 -0.4274447 -2.093444586 -2.25505304
		 0.4274447 -2.093444586 -2.25505304 0.4274447 -2.78859997 -1.176301 -0.4274447 -2.78859997 -1.176301
		 0.72106051 -0.6453988 -1.16880035 0.85051072 -0.9089759 -0.75977612 1.0079280138 -1.48406243 -1.049868584
		 0.84180027 -1.11797738 -1.61796379 1.19323182 -0.52520186 -1.17844582 1.25868881 -0.71871364 -0.87815094
		 1.40704048 -1.26846278 -1.20756149 1.32303739 -1.023117542 -1.58829165 -0.79805273 -0.1711607 2.0064849854
		 0.79805273 -0.1711607 2.0064849854 0.79805273 1.42494464 2.0064849854 -0.79805273 1.42494464 2.0064849854
		 0.3921743 -1.45555568 -1.84399271 -0.56172264 -1.45555568 -1.84399271 -0.56172264 -2.15071058 -0.76524162
		 0.3921743 -2.15071058 -0.76524162 0.58410996 -1.097224832 -1.60876703 0.66853529 -1.52866006 -0.93925858
		 0.67812788 -0.93385983 -0.67975998 0.61234188 -0.62999821 -1.15129566;
	setAttr -s 68 ".ed[0:67]"  0 1 0 2 3 0 4 5 1 6 7 1 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 1 5 7 0 6 0 0 7 1 0 4 8 0 5 9 1 8 9 1 7 10 1 9 10 0 6 11 0 11 10 1 8 11 1
		 8 29 0 9 28 0 12 13 0 10 31 0 13 14 0 11 30 0 15 14 0 12 15 0 5 35 0 7 34 0 16 17 1
		 10 33 0 17 18 1 9 32 0 19 18 1 16 19 1 16 20 0 17 21 0 20 21 0 18 22 0 21 22 0 19 23 0
		 23 22 0 20 23 0 0 24 0 1 25 0 24 25 0 3 26 0 25 26 0 2 27 0 27 26 0 24 27 0 28 13 0
		 29 12 0 28 29 1 30 15 0 29 30 1 31 14 0 30 31 1 31 28 1 32 19 0 33 18 0 32 33 1 34 17 0
		 33 34 1 35 16 0 34 35 1 35 32 1;
	setAttr -s 33 -ch 132 ".fc[0:32]" -type "polyFaces" 
		f 4 1 7 -3 -7
		mu 0 4 0 1 2 3
		f 4 22 24 -27 -28
		mu 0 4 4 5 6 7
		f 4 3 11 -1 -11
		mu 0 4 8 9 10 11
		f 4 -12 -10 -8 -6
		mu 0 4 12 13 14 1
		f 4 10 4 6 8
		mu 0 4 15 16 0 17
		f 4 2 13 -15 -13
		mu 0 4 3 2 18 19
		f 4 38 40 -43 -44
		mu 0 4 20 21 22 23
		f 4 -4 17 18 -16
		mu 0 4 9 8 24 25
		f 4 -9 12 19 -18
		mu 0 4 8 3 19 24
		f 4 14 21 54 -21
		mu 0 4 19 18 26 27
		f 4 16 23 59 -22
		mu 0 4 18 25 28 26
		f 4 -19 25 58 -24
		mu 0 4 25 24 29 28
		f 4 -20 20 56 -26
		mu 0 4 24 19 27 29
		f 4 9 29 66 -29
		mu 0 4 2 9 30 31
		f 4 15 31 64 -30
		mu 0 4 9 25 32 30
		f 4 -17 33 62 -32
		mu 0 4 25 18 33 32
		f 4 -14 28 67 -34
		mu 0 4 18 2 31 33
		f 4 30 37 -39 -37
		mu 0 4 34 35 21 20
		f 4 32 39 -41 -38
		mu 0 4 35 36 22 21
		f 4 -35 41 42 -40
		mu 0 4 36 37 23 22
		f 4 -36 36 43 -42
		mu 0 4 37 34 20 23
		f 4 0 45 -47 -45
		mu 0 4 16 12 38 39
		f 4 5 47 -49 -46
		mu 0 4 12 1 40 38
		f 4 -2 49 50 -48
		mu 0 4 1 0 41 40
		f 4 -5 44 51 -50
		mu 0 4 0 16 39 41
		f 4 -55 52 -23 -54
		mu 0 4 27 26 5 4
		f 4 -57 53 27 -56
		mu 0 4 29 27 4 7
		f 4 -59 55 26 -58
		mu 0 4 28 29 7 6
		f 4 -60 57 -25 -53
		mu 0 4 26 28 6 5
		f 4 -63 60 34 -62
		mu 0 4 32 33 37 36
		f 4 -65 61 -33 -64
		mu 0 4 30 32 36 35
		f 4 -67 63 -31 -66
		mu 0 4 31 30 35 34
		f 4 -68 65 35 -61
		mu 0 4 33 31 34 37;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 3;
	setAttr ".dsm" 2;
createNode transform -n "polySurface2" -p "pCube1";
	rename -uid "5531C0F2-4AF2-B2CF-1931-028D9D8CF7D3";
	setAttr ".t" -type "double3" -0.1224927588998221 4.1334565083376109 5.6397456055116892 ;
	setAttr ".s" -type "double3" 0.597716610984662 0.597716610984662 0.597716610984662 ;
	setAttr ".rp" -type "double3" 0.30449387431144714 -0.68182766437530518 -18.714032173156738 ;
	setAttr ".sp" -type "double3" 0.30449387431144714 -0.68182766437530518 -18.714032173156738 ;
	setAttr ".spt" -type "double3" 1.3877787807814457e-17 0 -8.8817841970012523e-16 ;
createNode transform -n "transform1" -p "polySurface2";
	rename -uid "BBA7E552-4BA8-77D9-99F9-4A8F67D28E68";
	setAttr ".v" no;
createNode mesh -n "polySurfaceShape2" -p "transform1";
	rename -uid "07C57163-44B5-4114-18C6-ED82C0AA1B34";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 33 "f[0]" "f[1]" "f[2]" "f[3]" "f[4]" "f[5]" "f[6]" "f[7]" "f[8]" "f[9]" "f[10]" "f[11]" "f[12]" "f[13]" "f[14]" "f[15]" "f[16]" "f[17]" "f[18]" "f[19]" "f[20]" "f[21]" "f[22]" "f[23]" "f[24]" "f[25]" "f[26]" "f[27]" "f[28]" "f[29]" "f[30]" "f[31]" "f[32]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 42 ".uvst[0].uvsp[0:41]" -type "float2" 0.375 0.25 0.375
		 0.5 0.625 0.5 0.625 0.25 0.375 0.5 0.375 0.75 0.625 0.75 0.625 0.5 0.375 0.75 0.375
		 1 0.625 1 0.625 0.75 0.625 0 0.875 0.25 0.875 0 0.125 0 0.125 0.25 0.375 0 0.375
		 0.5 0.625 0.5 0.625 0.5 0.625 0.5 0.625 0.75 0.625 0.75 0.625 0.75 0.375 0.75 0.375
		 0.5 0.625 0.5 0.625 0.75 0.375 0.75 0.625 0.5 0.625 0.75 0.625 0.75 0.625 0.5 0.625
		 0.5 0.625 0.75 0.625 0.75 0.625 0.5 0.375 0 0.625 0 0.625 0.25 0.375 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 36 ".vt[0:35]"  -0.5 -0.5 -19.33831406 0.5 -0.5 -19.33831406
		 -0.5 0.5 -19.33831406 0.5 0.5 -19.33831406 -0.5 -0.6140852 -17.70510483 0.5 -0.6140852 -17.70510483
		 -0.5 -1.15576422 -18.54569244 0.5 -1.15576422 -18.54569244 -0.64166665 -1.075780511 -17.23905182
		 0.31783155 -1.075780511 -17.23905182 0.31783155 -1.77093565 -18.31780243 -0.64166665 -1.77093565 -18.31780243
		 -0.4274447 -2.093444586 -16.5832634 0.4274447 -2.093444586 -16.5832634 0.4274447 -2.78859997 -17.66201401
		 -0.4274447 -2.78859997 -17.66201401 0.72106051 -0.6453988 -17.66951561 0.85051072 -0.9089759 -18.078540802
		 1.0079280138 -1.48406243 -17.78844833 0.84180027 -1.11797738 -17.22035217 1.19323182 -0.52520186 -17.65987015
		 1.25868881 -0.71871364 -17.96016693 1.40704048 -1.26846278 -17.63075638 1.32303739 -1.023117542 -17.2500248
		 -0.79805273 -0.1711607 -20.84480095 0.79805273 -0.1711607 -20.84480095 0.79805273 1.42494464 -20.84480095
		 -0.79805273 1.42494464 -20.84480095 0.3921743 -1.45555568 -16.99432373 -0.56172264 -1.45555568 -16.99432373
		 -0.56172264 -2.15071058 -18.073074341 0.3921743 -2.15071058 -18.073074341 0.58410996 -1.097224832 -17.22954941
		 0.66853529 -1.52866006 -17.89905739 0.67812788 -0.93385983 -18.15855598 0.61234188 -0.62999821 -17.68701935;
	setAttr -s 68 ".ed[0:67]"  2 3 0 3 5 0 4 5 1 2 4 0 12 13 0 13 14 0 15 14 0
		 12 15 0 6 7 1 7 1 0 0 1 0 6 0 0 5 7 0 1 3 0 0 2 0 4 6 1 5 9 1 8 9 1 4 8 0 20 21 0
		 21 22 0 23 22 0 20 23 0 6 11 0 11 10 1 7 10 1 8 11 1 9 28 0 28 29 1 8 29 0 9 10 0
		 10 31 0 31 28 1 11 30 0 30 31 1 29 30 1 7 34 0 34 35 1 5 35 0 10 33 0 33 34 1 9 32 0
		 32 33 1 35 32 1 16 17 1 17 21 0 16 20 0 17 18 1 18 22 0 19 18 1 19 23 0 16 19 1 1 25 0
		 24 25 0 0 24 0 3 26 0 25 26 0 2 27 0 27 26 0 24 27 0 28 13 0 29 12 0 30 15 0 31 14 0
		 32 19 0 33 18 0 34 17 0 35 16 0;
	setAttr -s 33 -ch 132 ".fc[0:32]" -type "polyFaces" 
		f 4 3 2 -2 -1
		mu 0 4 0 1 2 3
		f 4 7 6 -6 -5
		mu 0 4 4 5 6 7
		f 4 11 10 -10 -9
		mu 0 4 8 9 10 11
		f 4 13 1 12 9
		mu 0 4 12 3 13 14
		f 4 -16 -4 -15 -12
		mu 0 4 15 16 0 17
		f 4 18 17 -17 -3
		mu 0 4 1 18 19 2
		f 4 22 21 -21 -20
		mu 0 4 20 21 22 23
		f 4 25 -25 -24 8
		mu 0 4 11 24 25 8
		f 4 23 -27 -19 15
		mu 0 4 8 25 18 1
		f 4 29 -29 -28 -18
		mu 0 4 18 26 27 19
		f 4 27 -33 -32 -31
		mu 0 4 19 27 28 24
		f 4 31 -35 -34 24
		mu 0 4 24 28 29 25
		f 4 33 -36 -30 26
		mu 0 4 25 29 26 18
		f 4 38 -38 -37 -13
		mu 0 4 2 30 31 11
		f 4 36 -41 -40 -26
		mu 0 4 11 31 32 24
		f 4 39 -43 -42 30
		mu 0 4 24 32 33 19
		f 4 41 -44 -39 16
		mu 0 4 19 33 30 2
		f 4 46 19 -46 -45
		mu 0 4 34 20 23 35
		f 4 45 20 -49 -48
		mu 0 4 35 23 22 36
		f 4 48 -22 -51 49
		mu 0 4 36 22 21 37
		f 4 50 -23 -47 51
		mu 0 4 37 21 20 34
		f 4 54 53 -53 -11
		mu 0 4 17 38 39 12
		f 4 52 56 -56 -14
		mu 0 4 12 39 40 3
		f 4 55 -59 -58 0
		mu 0 4 3 40 41 0
		f 4 57 -60 -55 14
		mu 0 4 0 41 38 17
		f 4 61 4 -61 28
		mu 0 4 26 4 7 27
		f 4 62 -8 -62 35
		mu 0 4 29 5 4 26
		f 4 63 -7 -63 34
		mu 0 4 28 6 5 29
		f 4 60 5 -64 32
		mu 0 4 27 7 6 28
		f 4 65 -50 -65 42
		mu 0 4 32 36 37 33
		f 4 66 47 -66 40
		mu 0 4 31 35 36 32
		f 4 67 44 -67 37
		mu 0 4 30 34 35 31
		f 4 64 -52 -68 43
		mu 0 4 33 37 34 30;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 3;
	setAttr ".dsm" 2;
createNode transform -n "pCube2";
	rename -uid "331AE2BB-4E60-4AD9-DA83-BBBC524D6189";
	setAttr ".t" -type "double3" 0 0.57014466515102979 -0.6 ;
	setAttr ".s" -type "double3" 0.43295721937784748 1.3833000357751148 0.43295721937784748 ;
createNode mesh -n "pCubeShape2" -p "pCube2";
	rename -uid "30256CB4-4181-E8C8-CF68-64923964182A";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.375 0.875 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 32 ".pt";
	setAttr ".pt[0]" -type "float3" -0.14129947 0.0093046147 0.06440413 ;
	setAttr ".pt[1]" -type "float3" -0.012491211 0.0093046147 0.06440413 ;
	setAttr ".pt[6]" -type "float3" -0.14129947 0.0093046147 -0.064404108 ;
	setAttr ".pt[7]" -type "float3" -0.012491211 0.0093046147 -0.064404108 ;
	setAttr ".pt[8]" -type "float3" 0 0 0.32165897 ;
	setAttr ".pt[11]" -type "float3" 0 0 -0.32165897 ;
	setAttr ".pt[12]" -type "float3" -0.13150415 -0.096452728 0.13942508 ;
	setAttr ".pt[13]" -type "float3" -0.13150415 -0.096452728 -0.13942508 ;
	setAttr ".pt[14]" -type "float3" -0.085905455 -0.0083274422 0.28713983 ;
	setAttr ".pt[15]" -type "float3" -0.085905455 -0.0083274422 -0.28713983 ;
	setAttr ".pt[16]" -type "float3" 0.10865739 0.12967484 -0.07846535 ;
	setAttr ".pt[17]" -type "float3" 0.10865739 0.12967484 0.07846535 ;
	setAttr ".pt[20]" -type "float3" 0.155827 0.00055154832 -0.039912622 ;
	setAttr ".pt[21]" -type "float3" 0.155827 0.00055154832 0.03991263 ;
	setAttr ".pt[24]" -type "float3" 0.10865739 -0.013920223 -0.07846535 ;
	setAttr ".pt[25]" -type "float3" -0.012491211 -0.013920223 -0.064404108 ;
	setAttr ".pt[26]" -type "float3" -0.14129947 -0.013920223 0.18889934 ;
	setAttr ".pt[27]" -type "float3" -0.15582702 -0.0084084813 -0.04570381 ;
	setAttr ".pt[28]" -type "float3" -0.15582702 -0.0084084813 0.045703821 ;
	setAttr ".pt[29]" -type "float3" -0.14129947 -0.013920223 -0.18889928 ;
	setAttr ".pt[30]" -type "float3" -0.012491211 -0.013920223 0.06440413 ;
	setAttr ".pt[31]" -type "float3" 0.10865739 -0.013920223 0.07846535 ;
	setAttr ".pt[32]" -type "float3" 0.155827 -0.013920223 0.03991263 ;
	setAttr ".pt[33]" -type "float3" 0.155827 -0.013920223 -0.039912622 ;
	setAttr ".pt[34]" -type "float3" -0.0091317669 -0.013920223 -0.064794026 ;
	setAttr ".pt[35]" -type "float3" 0.15960357 0.060049362 -0.064794026 ;
	setAttr ".pt[36]" -type "float3" 0.15960357 0.060049362 0.064794034 ;
	setAttr ".pt[37]" -type "float3" -0.0091317669 -0.013920223 0.064794034 ;
	setAttr ".pt[40]" -type "float3" 0.28616375 2.220446e-16 -0.28616375 ;
	setAttr ".pt[41]" -type "float3" -0.28616375 2.220446e-16 -0.28616375 ;
	setAttr ".pt[42]" -type "float3" -0.28616375 2.220446e-16 0.28616375 ;
	setAttr ".pt[43]" -type "float3" 0.28616375 2.220446e-16 0.28616375 ;
	setAttr ".dr" 3;
	setAttr ".dsm" 2;
createNode transform -n "pCube3";
	rename -uid "ADC206B9-4D41-085D-9D1C-61817805872A";
	setAttr ".t" -type "double3" 0 0.57014466515102979 0.6 ;
	setAttr ".s" -type "double3" 0.43295721937784748 1.3833000357751148 0.43295721937784748 ;
createNode mesh -n "pCubeShape3" -p "pCube3";
	rename -uid "1CD197AD-478E-2C2E-2570-60A226E6FB0B";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.375 0.875 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 50 ".uvst[0].uvsp[0:49]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.375 0.75 0.625 0.75 0.625 1 0.375 1 0.375 1 0.375
		 0.75 0.375 0.75 0.375 1 0.625 0.75 0.625 1 0.625 1 0.625 0.75 0.625 0.75 0.625 1
		 0.625 1 0.625 0.75 0.625 0.75 0.625 0.75 0.375 0.75 0.375 0.75 0.375 1 0.375 1 0.625
		 1 0.625 1 0.625 1 0.625 0.75 0.625 0.75 0.625 0.75 0.625 1 0.625 1 0.625 1 0.625
		 0.75 0.375 0.25 0.625 0.25 0.625 0.5 0.375 0.5;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 32 ".pt";
	setAttr ".pt[0]" -type "float3" -0.14129947 0.0093046147 0.06440413 ;
	setAttr ".pt[1]" -type "float3" -0.012491211 0.0093046147 0.06440413 ;
	setAttr ".pt[6]" -type "float3" -0.14129947 0.0093046147 -0.064404108 ;
	setAttr ".pt[7]" -type "float3" -0.012491211 0.0093046147 -0.064404108 ;
	setAttr ".pt[8]" -type "float3" 0 0 0.32165897 ;
	setAttr ".pt[11]" -type "float3" 0 0 -0.32165897 ;
	setAttr ".pt[12]" -type "float3" -0.13150415 -0.096452728 0.13942508 ;
	setAttr ".pt[13]" -type "float3" -0.13150415 -0.096452728 -0.13942508 ;
	setAttr ".pt[14]" -type "float3" -0.085905455 -0.0083274422 0.28713983 ;
	setAttr ".pt[15]" -type "float3" -0.085905455 -0.0083274422 -0.28713983 ;
	setAttr ".pt[16]" -type "float3" 0.10865739 0.12967484 -0.07846535 ;
	setAttr ".pt[17]" -type "float3" 0.10865739 0.12967484 0.07846535 ;
	setAttr ".pt[20]" -type "float3" 0.155827 0.00055154832 -0.039912622 ;
	setAttr ".pt[21]" -type "float3" 0.155827 0.00055154832 0.03991263 ;
	setAttr ".pt[24]" -type "float3" 0.10865739 -0.013920223 -0.07846535 ;
	setAttr ".pt[25]" -type "float3" -0.012491211 -0.013920223 -0.064404108 ;
	setAttr ".pt[26]" -type "float3" -0.14129947 -0.013920223 0.18889934 ;
	setAttr ".pt[27]" -type "float3" -0.15582702 -0.0084084813 -0.04570381 ;
	setAttr ".pt[28]" -type "float3" -0.15582702 -0.0084084813 0.045703821 ;
	setAttr ".pt[29]" -type "float3" -0.14129947 -0.013920223 -0.18889928 ;
	setAttr ".pt[30]" -type "float3" -0.012491211 -0.013920223 0.06440413 ;
	setAttr ".pt[31]" -type "float3" 0.10865739 -0.013920223 0.07846535 ;
	setAttr ".pt[32]" -type "float3" 0.155827 -0.013920223 0.03991263 ;
	setAttr ".pt[33]" -type "float3" 0.155827 -0.013920223 -0.039912622 ;
	setAttr ".pt[34]" -type "float3" -0.0091317669 -0.013920223 -0.064794026 ;
	setAttr ".pt[35]" -type "float3" 0.15960357 0.060049362 -0.064794026 ;
	setAttr ".pt[36]" -type "float3" 0.15960357 0.060049362 0.064794034 ;
	setAttr ".pt[37]" -type "float3" -0.0091317669 -0.013920223 0.064794034 ;
	setAttr ".pt[40]" -type "float3" 0.28616375 2.220446e-16 -0.28616375 ;
	setAttr ".pt[41]" -type "float3" -0.28616375 2.220446e-16 -0.28616375 ;
	setAttr ".pt[42]" -type "float3" -0.28616375 2.220446e-16 0.28616375 ;
	setAttr ".pt[43]" -type "float3" 0.28616375 2.220446e-16 0.28616375 ;
	setAttr -s 44 ".vt[0:43]"  -0.5 -0.5 0.49999994 0.5 -0.5 0.49999994
		 -0.5 0.5 0.49999994 0.5 0.5 0.49999994 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5
		 0.5 -0.5 -0.5 -0.5 -0.72219384 -0.5 0.5 -0.72219384 -0.5 0.5 -0.72219384 0.49999994
		 -0.5 -0.72219384 0.49999994 -0.61278445 -0.45720977 -0.35482073 -0.61278445 -0.45720977 0.35482049
		 -0.61278445 -0.6794036 -0.35482073 -0.61278445 -0.6794036 0.35482049 1.44053447 -0.5 -0.60916424
		 1.44053447 -0.5 0.60916388 1.44053447 -0.72219384 0.60916388 1.44053447 -0.72219384 -0.60916424
		 1.80673492 -0.5 -0.30986094 1.80673492 -0.5 0.30986071 1.80673492 -0.72219384 0.30986071
		 1.80673492 -0.72219384 -0.30986094 1.44053447 -0.68030554 -0.60916424 0.5 -0.68030554 -0.5
		 -0.5 -0.68030554 -0.5 -0.61278445 -0.63751525 -0.35482073 -0.61278445 -0.63751525 0.35482049
		 -0.5 -0.68030554 0.49999994 0.5 -0.68030554 0.49999994 1.44053447 -0.68030554 0.60916388
		 1.80673492 -0.68030554 0.30986071 1.80673492 -0.68030554 -0.30986094 0.52608097 -0.68030554 -0.5030272
		 0.52608097 -0.5 -0.5030272 0.52608097 -0.5 0.50302696 0.52608097 -0.68030554 0.50302696
		 0.52608097 -0.72219384 0.50302696 0.52608097 -0.72219384 -0.5030272 -0.83417529 0.53894186 0.83417523
		 0.83417529 0.53894186 0.83417523 0.83417529 0.53894186 -0.83417529 -0.83417529 0.53894186 -0.83417529;
	setAttr -s 84 ".ed[0:83]"  0 1 1 2 3 1 4 5 1 6 7 1 0 2 0 1 3 0 2 4 1
		 3 5 1 4 6 0 5 7 0 6 0 0 7 1 0 6 26 1 7 25 1 8 9 0 1 30 1 9 10 1 0 29 1 11 10 0 8 11 1
		 6 12 0 0 13 0 12 13 0 8 14 0 12 27 0 11 15 0 14 15 0 13 28 0 7 35 0 1 36 0 16 17 1
		 10 38 0 17 31 0 9 39 0 19 18 1 16 24 0 16 20 0 17 21 0 20 21 0 18 22 0 21 32 0 19 23 0
		 23 22 0 20 33 0 24 19 0 25 9 1 24 34 1 26 8 1 25 26 1 27 14 0 26 27 1 28 15 0 27 28 1
		 29 11 1 28 29 1 30 10 1 29 30 1 31 18 0 30 37 1 32 22 0 31 32 1 33 23 0 32 33 1 33 24 1
		 34 25 1 35 16 0 34 35 1 36 17 0 35 36 1 37 31 1 36 37 1 38 18 0 37 38 1 39 19 0 38 39 1
		 39 34 1 2 40 0 3 41 0 40 41 0 5 42 0 41 42 0 4 43 0 43 42 0 40 43 0;
	setAttr -s 41 -ch 164 ".fc[0:40]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 2 9 -4 -9
		mu 0 4 4 5 7 6
		f 4 14 16 -19 -20
		mu 0 4 14 15 16 17
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13
		f 4 3 13 48 -13
		mu 0 4 6 7 31 32
		f 4 38 40 62 -44
		mu 0 4 26 27 38 39
		f 4 -1 17 56 -16
		mu 0 4 9 8 35 36
		f 4 -23 24 52 -28
		mu 0 4 18 19 33 34
		f 4 -11 20 22 -22
		mu 0 4 8 6 19 18
		f 4 12 50 -25 -21
		mu 0 4 6 32 33 19
		f 4 19 25 -27 -24
		mu 0 4 14 17 21 20
		f 4 -18 21 27 54
		mu 0 4 35 8 18 34
		f 4 68 67 -31 -66
		mu 0 4 41 42 23 22
		f 4 70 69 -33 -68
		mu 0 4 42 43 37 23
		f 4 74 73 34 -72
		mu 0 4 44 45 25 24
		f 4 66 65 35 46
		mu 0 4 40 41 22 30
		f 4 30 37 -39 -37
		mu 0 4 22 23 27 26
		f 4 32 60 -41 -38
		mu 0 4 23 37 38 27
		f 4 -35 41 42 -40
		mu 0 4 24 25 29 28
		f 4 63 -36 36 43
		mu 0 4 39 30 22 26
		f 4 75 -47 44 -74
		mu 0 4 45 40 30 25
		f 4 -49 45 -15 -48
		mu 0 4 32 31 15 14
		f 4 -51 47 23 -50
		mu 0 4 33 32 14 20
		f 4 -53 49 26 -52
		mu 0 4 34 33 20 21
		f 4 -54 -55 51 -26
		mu 0 4 17 35 34 21
		f 4 -57 53 18 -56
		mu 0 4 36 35 17 16
		f 4 -70 72 71 -58
		mu 0 4 37 43 44 24
		f 4 -61 57 39 -60
		mu 0 4 38 37 24 28
		f 4 -63 59 -43 -62
		mu 0 4 39 38 28 29
		f 4 -45 -64 61 -42
		mu 0 4 25 30 39 29
		f 4 -14 28 -67 64
		mu 0 4 31 7 41 40
		f 4 11 29 -69 -29
		mu 0 4 7 9 42 41
		f 4 15 58 -71 -30
		mu 0 4 9 36 43 42
		f 4 -73 -59 55 31
		mu 0 4 44 43 36 16
		f 4 -17 33 -75 -32
		mu 0 4 16 15 45 44
		f 4 -46 -65 -76 -34
		mu 0 4 15 31 40 45
		f 4 1 77 -79 -77
		mu 0 4 2 3 47 46
		f 4 7 79 -81 -78
		mu 0 4 3 5 48 47
		f 4 -3 81 82 -80
		mu 0 4 5 4 49 48
		f 4 -7 76 83 -82
		mu 0 4 4 2 46 49;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 3;
	setAttr ".dsm" 2;
createNode transform -n "polySurface1";
	rename -uid "FAF4628F-4B30-1D98-C9F5-1A835E5D4A1C";
	setAttr ".t" -type "double3" 0 0 1.940263 ;
	setAttr ".rp" -type "double3" 0.096612181792347263 1.8322385786207245 -1.940262934278314 ;
	setAttr ".sp" -type "double3" 0.096612181792347263 1.8322385786207245 -1.940262934278314 ;
createNode transform -n "polySurface3" -p "|polySurface1";
	rename -uid "3828233A-425F-02E7-3563-638DF9363075";
	setAttr ".t" -type "double3" 0 0 -2 ;
createNode mesh -n "polySurfaceShape3" -p "polySurface3";
	rename -uid "A769BA26-48B9-5C69-E6E9-968062850347";
	setAttr -k off ".v";
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".dr" 3;
	setAttr ".dsm" 2;
createNode transform -n "polySurface4" -p "|polySurface1";
	rename -uid "B46688A6-40B7-8671-BAC7-5D8288962390";
	setAttr ".t" -type "double3" 0 0 2 ;
createNode mesh -n "polySurfaceShape4" -p "polySurface4";
	rename -uid "38966A78-47A1-497E-444B-94A86D6189BC";
	setAttr -k off ".v";
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".dr" 3;
	setAttr ".dsm" 2;
createNode transform -n "transform3" -p "|polySurface1";
	rename -uid "A1582C1A-43F4-CBD2-0805-3CB8BC4B5DC7";
	setAttr ".v" no;
createNode mesh -n "polySurface1Shape" -p "transform3";
	rename -uid "1B89356F-4AD0-AF31-2D01-3683B2760D8E";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".dsm" 2;
createNode lightLinker -s -n "lightLinker1";
	rename -uid "1348E7FE-42B2-10C4-7979-9F8C67DF1B1B";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "554A613C-4964-3C05-F38C-F5AE1FAC350C";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "04B9C5CC-487C-0A80-9DD9-D3A7A453F325";
createNode displayLayerManager -n "layerManager";
	rename -uid "AE092FEF-431B-85E7-C5DB-6FADE1920E1A";
createNode displayLayer -n "defaultLayer";
	rename -uid "57CF3F14-4F36-6394-D064-C6905A2C7CFC";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "3C56784C-4FCE-1F60-B734-04A35697EF88";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "48E8A8EB-4FCE-B654-1788-3BA242B8A0F7";
	setAttr ".g" yes;
createNode polyCube -n "polyCube2";
	rename -uid "CA9F750E-495D-EDDD-85D5-F6B4E9878FEC";
	setAttr ".cuv" 4;
createNode polyExtrudeFace -n "polyExtrudeFace6";
	rename -uid "A35E0774-4182-E7C3-2852-0382C7C76865";
	setAttr ".ics" -type "componentList" 1 "f[3]";
	setAttr ".ix" -type "matrix" 0.79581646583970878 0 0 0 0 2.542636769629115 0 0 0 0 0.79581646583970878 0
		 0 0 -1.1917210746439881 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 -1.2713184 -1.1917211 ;
	setAttr ".rs" 51727;
	setAttr ".lt" -type "double3" 0 0 0.56495809493805904 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.39790823291985439 -1.2713183848145575 -1.5896293075638426 ;
	setAttr ".cbx" -type "double3" 0.39790823291985439 -1.2713183848145575 -0.79381284172413369 ;
createNode polyExtrudeFace -n "polyExtrudeFace7";
	rename -uid "12DBA2A5-477C-DCF1-BCEC-8ABD315EE7E9";
	setAttr ".ics" -type "componentList" 1 "f[9]";
	setAttr ".ix" -type "matrix" 0.79581646583970878 0 0 0 0 2.542636769629115 0 0 0 0 0.79581646583970878 0
		 0 0 -1.1917210746439881 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" -0.39790824 -1.5537975 -1.1917211 ;
	setAttr ".rs" 62668;
	setAttr ".lt" -type "double3" 0 0 0.61934298345452632 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -0.39790823291985439 -1.8362766051773876 -1.5896293075638426 ;
	setAttr ".cbx" -type "double3" -0.39790823291985439 -1.2713183848145575 -0.79381288915849146 ;
createNode polyExtrudeFace -n "polyExtrudeFace8";
	rename -uid "FC9AAA7B-4777-20BC-B275-E2B993B4914B";
	setAttr ".ics" -type "componentList" 1 "f[7]";
	setAttr ".ix" -type "matrix" 0.79581646583970878 0 0 0 0 2.542636769629115 0 0 0 0 0.79581646583970878 0
		 0 0 -1.1917210746439881 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.39790824 -1.5537975 -1.1917211 ;
	setAttr ".rs" 46920;
	setAttr ".lt" -type "double3" 0 -1.3038067839418393e-16 0.74849276211449189 ;
	setAttr ".ls" -type "double3" 1.2183277933906902 1 0.78561037971147962 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 0.39790823291985439 -1.8362766051773876 -1.5896293075638426 ;
	setAttr ".cbx" -type "double3" 0.39790823291985439 -1.2713183848145575 -0.79381288915849146 ;
createNode polyTweak -n "polyTweak7";
	rename -uid "40ABBFB4-4EA5-C133-3466-448C94139232";
	setAttr ".uopa" yes;
	setAttr -s 9 ".tk";
	setAttr ".tk[12]" -type "float3" 0 0 0.14517941 ;
	setAttr ".tk[13]" -type "float3" 0 0 -0.14517941 ;
	setAttr ".tk[14]" -type "float3" 0 0 0.14517941 ;
	setAttr ".tk[15]" -type "float3" 0 0 -0.14517941 ;
createNode polyExtrudeFace -n "polyExtrudeFace9";
	rename -uid "E3A1574D-4A1D-B974-B2FB-01B1110A8D07";
	setAttr ".ics" -type "componentList" 1 "f[7]";
	setAttr ".ix" -type "matrix" 0.79581646583970878 0 0 0 0 2.542636769629115 0 0 0 0 0.79581646583970878 0
		 0 0 -1.1917210746439881 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 1.146401 -1.5537975 -1.1917211 ;
	setAttr ".rs" 34023;
	setAttr ".lt" -type "double3" 0 2.577342884577837e-16 0.2914283821065875 ;
	setAttr ".ls" -type "double3" 0.5086656866458994 1 1 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 1.1464010527977755 -1.8362766051773876 -1.6765038158886159 ;
	setAttr ".cbx" -type "double3" 1.1464010527977755 -1.2713183848145575 -0.70693842826807596 ;
createNode polySplitRing -n "polySplitRing3";
	rename -uid "FAD1B040-4D0D-6B56-455B-3186F8E294DD";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 9 "e[12:13]" "e[15]" "e[17]" "e[24]" "e[27]" "e[32]" "e[35]" "e[40]" "e[43]";
	setAttr ".ix" -type "matrix" 0.79581646583970878 0 0 0 0 2.542636769629115 0 0 0 0 0.79581646583970878 0
		 0 0 -1.1917210746439881 1;
	setAttr ".wt" 0.81147807836532593;
	setAttr ".dr" no;
	setAttr ".re" 35;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyTweak -n "polyTweak8";
	rename -uid "B98CEBC8-4A86-770C-C9F2-6B84F06EC7D0";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[12:15]" -type "float3"  0.6654641 0.042790223 0 0.6654641
		 0.042790223 0 0.6654641 0.042790223 0 0.6654641 0.042790223 0;
createNode polySplitRing -n "polySplitRing4";
	rename -uid "B4CB269B-45A3-D05B-F874-FBBC83EFC743";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 5 "e[28:29]" "e[31]" "e[33]" "e[46]" "e[58]";
	setAttr ".ix" -type "matrix" 0.79581646583970878 0 0 0 0 2.542636769629115 0 0 0 0 0.79581646583970878 0
		 0 0 -1.1917210746439881 1;
	setAttr ".wt" 0.97227007150650024;
	setAttr ".dr" no;
	setAttr ".re" 46;
	setAttr ".sma" 29.999999999999996;
	setAttr ".p[0]"  0 0 1;
	setAttr ".fq" yes;
createNode polyExtrudeFace -n "polyExtrudeFace10";
	rename -uid "8CDCBDA5-4FF6-9A3D-F5B5-4D8A21C4F2EC";
	setAttr ".ics" -type "componentList" 1 "f[1]";
	setAttr ".ix" -type "matrix" 0.79581646583970878 0 0 0 0 2.542636769629115 0 0 0 0 0.79581646583970878 0
		 0 0 -1.1917210746439881 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 1.2713184 -1.1917211 ;
	setAttr ".rs" 51981;
	setAttr ".lt" -type "double3" 0 0 -0.10098514914005174 ;
	setAttr ".c[0]"  0 1 1;
	setAttr ".tk" 0.20000000298023224;
	setAttr ".cbn" -type "double3" -0.39790823291985439 1.2713183848145575 -1.5896293075638426 ;
	setAttr ".cbx" -type "double3" 0.39790823291985439 1.2713183848145575 -0.79381288915849146 ;
createNode polyTweak -n "polyTweak9";
	rename -uid "B9DB8715-4581-0193-B3C9-E18982B5EC64";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[40:43]" -type "float3"  -0.33417529 0 0.33417529 0.33417529
		 0 0.33417529 0.33417529 0 -0.33417529 -0.33417529 0 -0.33417529;
createNode deleteComponent -n "deleteComponent2";
	rename -uid "4B3D8DEA-40B0-D6AB-4FA1-11BD0A14EAB3";
	setAttr ".dc" -type "componentList" 1 "f[1]";
createNode groupId -n "groupId5";
	rename -uid "0B19FED1-4A9F-0934-E7A5-52B78893CB4E";
	setAttr ".ihi" 0;
createNode groupId -n "groupId6";
	rename -uid "C3BF04E2-4300-96A7-9933-D1903941D0E0";
	setAttr ".ihi" 0;
createNode polyUnite -n "polyUnite1";
	rename -uid "41186E19-4EBF-7DD6-4449-B2BD0F1FBCD8";
	setAttr -s 2 ".ip";
	setAttr -s 2 ".im";
createNode groupId -n "groupId7";
	rename -uid "D742EB9B-4943-C662-0C1B-6C8414F3D0B8";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts1";
	rename -uid "DF7A3371-45BF-6969-8D83-9DB5B6576346";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:65]";
createNode polySeparate -n "polySeparate1";
	rename -uid "5AF3CB57-48B7-7061-8E06-9BA717231AE8";
	setAttr ".ic" 2;
	setAttr -s 2 ".out";
createNode groupId -n "groupId8";
	rename -uid "9FA6DA88-413F-3690-A9CA-26A1BDE0FD0E";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts2";
	rename -uid "482EA739-46C8-AD99-B403-E8B280CED5CE";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 33 "f[0]" "f[1]" "f[2]" "f[3]" "f[4]" "f[5]" "f[6]" "f[7]" "f[8]" "f[9]" "f[10]" "f[11]" "f[12]" "f[13]" "f[14]" "f[15]" "f[16]" "f[17]" "f[18]" "f[19]" "f[20]" "f[21]" "f[22]" "f[23]" "f[24]" "f[25]" "f[26]" "f[27]" "f[28]" "f[29]" "f[30]" "f[31]" "f[32]";
createNode groupId -n "groupId9";
	rename -uid "8A9EA797-4535-9223-0FA6-40A4C37223BD";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts3";
	rename -uid "89877C08-40F4-4072-A938-DC83AA75399A";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 33 "f[0]" "f[1]" "f[2]" "f[3]" "f[4]" "f[5]" "f[6]" "f[7]" "f[8]" "f[9]" "f[10]" "f[11]" "f[12]" "f[13]" "f[14]" "f[15]" "f[16]" "f[17]" "f[18]" "f[19]" "f[20]" "f[21]" "f[22]" "f[23]" "f[24]" "f[25]" "f[26]" "f[27]" "f[28]" "f[29]" "f[30]" "f[31]" "f[32]";
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 5 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr -s 7 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 5 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "groupId5.id" "polySurfaceShape1.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurfaceShape1.iog.og[0].gco";
connectAttr "groupId6.id" "polySurfaceShape2.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurfaceShape2.iog.og[0].gco";
connectAttr "deleteComponent2.og" "pCubeShape2.i";
connectAttr "groupParts2.og" "polySurfaceShape3.i";
connectAttr "groupId8.id" "polySurfaceShape3.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurfaceShape3.iog.og[0].gco";
connectAttr "groupParts3.og" "polySurfaceShape4.i";
connectAttr "groupId9.id" "polySurfaceShape4.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurfaceShape4.iog.og[0].gco";
connectAttr "groupParts1.og" "polySurface1Shape.i";
connectAttr "groupId7.id" "polySurface1Shape.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "polySurface1Shape.iog.og[0].gco";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyCube2.out" "polyExtrudeFace6.ip";
connectAttr "pCubeShape2.wm" "polyExtrudeFace6.mp";
connectAttr "polyExtrudeFace6.out" "polyExtrudeFace7.ip";
connectAttr "pCubeShape2.wm" "polyExtrudeFace7.mp";
connectAttr "polyTweak7.out" "polyExtrudeFace8.ip";
connectAttr "pCubeShape2.wm" "polyExtrudeFace8.mp";
connectAttr "polyExtrudeFace7.out" "polyTweak7.ip";
connectAttr "polyExtrudeFace8.out" "polyExtrudeFace9.ip";
connectAttr "pCubeShape2.wm" "polyExtrudeFace9.mp";
connectAttr "polyTweak8.out" "polySplitRing3.ip";
connectAttr "pCubeShape2.wm" "polySplitRing3.mp";
connectAttr "polyExtrudeFace9.out" "polyTweak8.ip";
connectAttr "polySplitRing3.out" "polySplitRing4.ip";
connectAttr "pCubeShape2.wm" "polySplitRing4.mp";
connectAttr "polySplitRing4.out" "polyExtrudeFace10.ip";
connectAttr "pCubeShape2.wm" "polyExtrudeFace10.mp";
connectAttr "polyExtrudeFace10.out" "polyTweak9.ip";
connectAttr "polyTweak9.out" "deleteComponent2.ig";
connectAttr "polySurfaceShape1.o" "polyUnite1.ip[0]";
connectAttr "polySurfaceShape2.o" "polyUnite1.ip[1]";
connectAttr "polySurfaceShape1.wm" "polyUnite1.im[0]";
connectAttr "polySurfaceShape2.wm" "polyUnite1.im[1]";
connectAttr "polyUnite1.out" "groupParts1.ig";
connectAttr "groupId7.id" "groupParts1.gi";
connectAttr "polySurface1Shape.o" "polySeparate1.ip";
connectAttr "polySeparate1.out[0]" "groupParts2.ig";
connectAttr "groupId8.id" "groupParts2.gi";
connectAttr "polySeparate1.out[1]" "groupParts3.ig";
connectAttr "groupId9.id" "groupParts3.gi";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pCubeShape2.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape3.iog" ":initialShadingGroup.dsm" -na;
connectAttr "polySurfaceShape1.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "polySurfaceShape2.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "polySurface1Shape.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "polySurfaceShape3.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "polySurfaceShape4.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "groupId5.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId6.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId7.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId8.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId9.msg" ":initialShadingGroup.gn" -na;
// End of NPC_Limbs.ma
