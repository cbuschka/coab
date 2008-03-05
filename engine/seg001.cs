using Classes;

namespace engine
{
    public class seg001
    {
        internal static System.Threading.Thread EngineThread;
        
        public delegate void VoidDelegate();
        static VoidDelegate EngineStoppedCallback;

        internal static void EngineStop()
        {
            EngineStoppedCallback();
            EngineThread.Abort();
        }

        public static void __SystemInit(VoidDelegate stoppedCallback  )
        {
            EngineThread = System.Threading.Thread.CurrentThread;
            EngineStoppedCallback = stoppedCallback;

            seg051.o_1_a_87_i_tpdos_idc_tpdos_l_tptv();

            gbl.byte_1EFA4 = "Wooden";

            seg044.sound_sub_121BF();
            seg039.config_game();
        }

        public static void PROGRAM()
        {
            /* Memory Init - Start */
            gbl.CombatMap = new gbl.Struct_1C9CD[gbl.stru_1C9CD_count+1]; /* God damm 1-n arrays */
            for (int i = 0; i <= gbl.stru_1C9CD_count; i++)
            {
                gbl.CombatMap[i] = new gbl.Struct_1C9CD();
            }
            
            gbl.unk_16620 = new byte[5, 6, 2]; // the 5 is made up.

            gbl.unk_1D1C1 = new gbl.Struct_1D1C1[gbl.unk_1D1C1_count];
            for (int i = 0; i < gbl.unk_1D1C1_count; i++)
            {
                gbl.unk_1D1C1[i] = new gbl.Struct_1D1C1();
            }
            /* Memory Init - End */

            seg044.sound_sub_12194();

			if( gbl.gameFlag01 == true )
			{
				seg044.sound_sub_120E0( gbl.word_188BC );
			}

            ovr012.sub_39054();

			if( gbl.gameFlag01 == false )
			{
				seg044.sound_sub_12194();
			}

			seg044.sound_sub_120E0( gbl.word_188BE );
            seg044.sound_sub_12194();

			if( seg051.ParamStr( 1 ) != "STING" )
			{
				ovr002.title_screen();
			}

			gbl.displayInputCentiSecondWait = 3000;
            gbl.displayInputTimeoutValue = 'D';
          
            gbl.byte_1AB06 = ovr027.displayInput( out gbl.unk_1AB07, false, 0, 15, 10, 13, "Play Demo", "Curse of the Azure Bonds v1.3 " );
 
            gbl.displayInputCentiSecondWait = 0;
            gbl.displayInputTimeoutValue = '\0';

			if( gbl.byte_1AB06 == 'D' )
			{
				gbl.inDemo = true;
			}

			if( seg051.ParamStr( 2 ) != gbl.byte_1EFA4 &&
				gbl.inDemo == false )
			{
				//ovr004.copy_protection();
			}

			while( true )
			{
				if( gbl.inDemo == true )
				{
					gbl.game_area = 1;
					gbl.game_speed_var = 9;
				}
				else
				{
					gbl.game_area = 2;
				}

				if( gbl.gameFlag01 == true )
				{
					seg044.sound_sub_120E0( gbl.word_188BC );
				}

				if( gbl.gameFlag01 == false )
				{
					seg044.sound_sub_12194();
				}

				if( gbl.inDemo == false )
				{
					ovr018.startGameMenu();
				}

				if( gbl.gameFlag01 == true )
				{
					seg044.sound_sub_120E0( gbl.word_188BC );
				}

				if( gbl.gameFlag01 == false )
				{
					seg044.sound_sub_12194();
				}

				if( gbl.gameFlag01 == true )
				{
					seg044.sound_sub_120E0( gbl.word_188BC );
				}

				if( gbl.gameFlag01 == false )
				{
					seg044.sound_sub_12194();
				}

				ovr003.sub_29758();

				if( gbl.gameFlag01 == true )
				{
					seg044.sound_sub_120E0( gbl.word_188BC );
				}

				if( gbl.gameFlag01 == false )
				{
					seg044.sound_sub_12194();
				}

				ovr012.sub_396E5();

				if( gbl.inDemo == true ) 
				{
					ovr002.title_screen();
					seg043.clear_keyboard();

					gbl.displayInputCentiSecondWait = 1000;
					gbl.displayInputTimeoutValue = 'D';
				
					gbl.byte_1AB06 = ovr027.displayInput( out gbl.unk_1AB07, false, 0, 15, 10, 13, "Play Demo", "Curse of the Azure Bonds v1.3 " );

					gbl.displayInputCentiSecondWait = 0;
                    gbl.displayInputTimeoutValue = '\0';

					gbl.inDemo = ( gbl.byte_1AB06 == 0x44 );

					if( seg051.ParamStr( 2 ) != gbl.byte_1EFA4 &&
						gbl.inDemo == false )
					{
						//ovr004.copy_protection();
					}
				
					seg044.sound_sub_120E0( gbl.word_188BE );
				}
			}
        }
    }
}
