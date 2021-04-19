using System;
using System.ComponentModel;
//using System.Threading;
using System.Windows.Forms;

// Adapter les treads & correct
// corriger hight

namespace IHM.Components.Animation
{

    /// <summary>
    /// Gérer le redimensionnement des objets de façon graduelle et dynamique.
    /// </summary>
    public class TacosCode_AutoResizeControl : Component
    {
        public TacosCode_AutoResizeControl() { SetDefaultParameters(); }

        public TacosCode_AutoResizeControl(System.Windows.Forms.Control control)
        {
            SetDefaultParameters();
            this.Control = control;
        }


        #region Control Parameters

        

        void SetDefaultParameters()
        {
            
            _timer_width_expansion.Tick += new System.EventHandler(Timer_width_expansion_Tick);
            _timer_width_contraction.Tick += new System.EventHandler(Timer_width_contraction_Tick);
            _timer_width_retardement.Tick += new System.EventHandler(Timer_width_retarding_resize_Tick);

            _timer_height_expansion.Tick += new System.EventHandler(Timer_height_expanding_Tick);
            _timer_height_contraction.Tick += new System.EventHandler(Timer_height_reducing_Tick);
            _timer_height_retardement.Tick += new System.EventHandler(Timer_height_retarding_resize_Tick);

            // Width parameters

            InitialWidth = 0;
            FinalWidth = 20;
            WidthExpansionInterval = 10;
            WidthContractionInterval = 10;
            TimerIntervalForWidthExpansion = 10;
            TimerIntervalForWidthContraction = 10;

            // Height parameters

            InitialHeight = 0;
            FinalHeight = 20;
            HeightExpansionInterval = 10;
            HeightContractionInterval = 10;
            TimerIntervalForHeightExpansion = 10;
            TimerIntervalForHeightContraction = 10;
        }

        void RefreshParameters()
        {
            if (Control != null)
            {
                this.Control.MouseEnter += new System.EventHandler(Auto_resize_MouseEnter);
                this.Control.MouseLeave += new System.EventHandler(Auto_resize_MouseLeave);
                this.Control.DockChanged += new System.EventHandler(Controle_DockChanged);
                dock = Control.Dock.ToString();

                InitialWidth = (ushort)Control.Width ;
                FinalWidth = 0;
                InitialHeight = (ushort)Control.Height ;
                FinalHeight = 0;
            }
        }


        System.Windows.Forms.Control _control;
        /// <summary>
        /// Le Control sur lequel appliquer les effets de redimension.
        /// </summary>
        [Browsable(true), Category("TacosCode: Targeted control"), DefaultValue(null), Description("Le Control sur lequel appliquer les effets de redimension.")]
        public Control Control  { get { return this._control; } set { this._control = value; RefreshParameters(); } }

        #endregion  Control Parameters


        #region Settings for resizing widt controle increasingly

        System.Windows.Forms.Timer _timer_width_expansion = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer _timer_width_contraction = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer _timer_width_retardement = new System.Windows.Forms.Timer();

        ushort _min_width;
        ushort _max_width;

        ushort _initial_width;
        /// <summary>
        /// La largeur initiale du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated width resizing"), DefaultValue(1), Description("La largeur initiale du controle.")]
        public ushort InitialWidth { get { return _initial_width; } set { _initial_width = value; RefreshMaxMinWidthValues();  } }

        ushort _final_width;
        /// <summary>
        /// La largeur finale du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated width resizing"), DefaultValue(0), Description("La largeur finale du controle.")]
        public ushort FinalWidth { get { return _final_width; } set { _final_width = value; RefreshMaxMinWidthValues(); } }

        string x= "";
        ushort _width_expansion_interval;
        /// <summary>
        /// L'intervalle d'expansion de la largeur du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated width resizing"), DefaultValue(1), Description("L'intervalle d'expansion de la largeur du controle.")]
        public ushort WidthExpansionInterval { get { return _width_expansion_interval; } set { _width_expansion_interval = value; } }

        ushort _width_contraction_interval;
        /// <summary>
        /// L'intervalle de contraction de la largeur du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated width resizing"), DefaultValue(1), Description("L'intervalle de contraction de la largeur du controle.")]
        public ushort WidthContractionInterval { get { return _width_contraction_interval; } set { _width_contraction_interval = value; } }

        /// <summary>
        /// L'intervalle du temps entre chaque expansion de la largeur du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated width resizing"), DefaultValue(1), Description("L'intervalle du temps entre chaque expansion de la largeur du controle.")]
        public ushort TimerIntervalForWidthExpansion { get { return (ushort)_timer_width_expansion.Interval; } set { _timer_width_expansion.Interval = value > 0 ? value : 1; } }

        /// <summary>
        /// L'intervalle du temps entre chaque contraction de la largeur du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated width resizing"), DefaultValue(1), Description("L'intervalle du temps entre chaque contraction de la largeur du controle.")]
        public ushort TimerIntervalForWidthContraction { get { return (ushort)_timer_width_contraction.Interval; } set { _timer_width_contraction.Interval = value > 0 ? value : 1; } }

        void RefreshMaxMinWidthValues()
        {
            if (_initial_width < _final_width)
            {
                _max_width = _final_width;
                _min_width = _initial_width;
            }
            else
            {
                _max_width = _initial_width;
                _min_width = _final_width;
            }

            if(Control != null)
                this.Control.Width = _initial_width;
        }

        /// <summary>
        /// Set parameters for animated width resizing.
        /// </summary>
        /// <param name="initialWidth">La largeur initiale du controle.</param>
        /// <param name="finalWidth">La largeur finale du controle.</param>
        /// <param name="widthExpansionInterval">L'intervalle d'expansion de la largeur du controle.</param>
        /// <param name="widthContractionInterval">L'intervalle de contraction de la largeur du controle.</param>
        /// <param name="timerIntervalForWidthExpansion">L'intervalle du temps entre chaque expansion de la largeur du controle.</param>
        /// <param name="timerIntervalForWidthContraction">L'intervalle du temps entre chaque contraction de la largeur du controle.</param>
        public void SetWidthResizeParameters(ushort initialWidth = 0, ushort finalWidth = 20, ushort widthExpansionInterval = 10,
            ushort widthContractionInterval = 10, ushort timerIntervalForWidthExpansion = 10, ushort timerIntervalForWidthContraction = 10)
        {
            try
            {
                InitialWidth = initialWidth;
                FinalWidth = finalWidth;

                WidthExpansionInterval = widthExpansionInterval;
                WidthContractionInterval = widthContractionInterval;

                _timer_width_expansion.Interval = timerIntervalForWidthExpansion;
                _timer_width_contraction.Interval = timerIntervalForWidthContraction;

                /*
                 * Lancer une un timer en multy thread
                 * Déconséllé pour windows form
                var time = new System.Threading.Timer(obj=>
                {
                    Console.WriteLine("hhhhhhhhh");

                },null,TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

                time.Dispose();
                */
            }
            catch (Exception x) { Msg.Show(x); }
        }


        void Timer_width_expansion_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Control.Width < _max_width) this.Control.Width += WidthExpansionInterval;
                else if (this.Control.Width >= _max_width) { this.Control.Width = _max_width; StopWidthResizing(); }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        void Timer_width_contraction_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Control.Width > _min_width && this.Control.Width - WidthContractionInterval > 0) this.Control.Width -= WidthContractionInterval;
                else { this.Control.Width = _min_width; StopWidthResizing(); }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        bool widthPasse;
        void Timer_width_retarding_resize_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!widthPasse)
                {
                    ContractWidth();
                    StopTimerRetardingWithResize();
                }
                else widthPasse = true;
            }
            catch (Exception x) { Msg.Show(x); }
        }


        void StopWidthResizing()
        {
            try
            {
                _timer_width_expansion.Stop();
                _timer_width_expansion.Dispose();

                _timer_width_contraction.Stop();
                _timer_width_contraction.Dispose();
            }
            catch (Exception x) { Msg.Show(x); }
        }

        void StopTimerRetardingWithResize()
        {
            try
            {
                _timer_width_retardement.Stop();
                _timer_width_retardement.Dispose();
            }
            catch (Exception x) { Msg.Show(x); }
        }

        
        /// <summary>
        /// Expansion de la largeur du controle.
        /// </summary>
        public void ExpandWidth()
        {
            try
            {
                if (this.Control != null)
                {
                    dock = Control.Dock.ToString();
                    if (!dock.Contains("Top") && !dock.Contains("Bottom") && !dock.Contains("Fill"))
                    {
                        StopWidthResizing();
                        _timer_width_expansion.Start();
                    }
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        /// <summary>
        /// Contraction de la largeur du controle.
        /// </summary>
        public void ContractWidth()
        {
            try
            {
                if (this.Control != null)
                {
                    dock = Control.Dock.ToString();
                    if (!dock.Contains("Top") && !dock.Contains("Bottom") && !dock.Contains("Fill"))
                    {
                        StopWidthResizing();
                        //Thread thread = new Thread(_timer_width_reducing.Start());
                        //thread.Start();
                        _timer_width_contraction.Start();
                    }
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        /// <summary>
        /// Expansion pui contraction la largeur du controle.
        /// </summary>
        public void ExpandAndReduceWidth(ushort retardementInterval = 1000)
        {
            try
            {
                _timer_width_retardement.Interval = retardementInterval > 0 ? retardementInterval : 1;
                widthPasse = false;
                ExpandWidth();
                _timer_width_retardement.Start();
            }
            catch (Exception x) { Msg.Show(x); }
        }

        /// <summary>
        /// Expansion ou contraction la largeur du controle.
        /// </summary>
        public void ExpandORReduceWidth()
        {

            // a corriger (non fluide)


            string s = "";
            int width = this.Control.Width;
            s += width.ToString();
            if (width != _max_width && width != _min_width)
            {
                s += "\n" + this.Control.Width;
                Msg.Show(s);
            }
            else if (this.Control.Width == _max_width) ContractWidth();
            else ExpandWidth();
            
        }

        /// <summary>
        /// Retourne true si la largeur du controle et actuellement au maximale. 
        /// </summary>
        public bool IfCurrentResizeStateWidthIsExpanding()
        { return this.Control.Width == _max_width; }

        #endregion Settings for resizing widt controle increasingly


        #region Settings for resizing height controle increasingly

        System.Windows.Forms.Timer _timer_height_expansion = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer _timer_height_contraction = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer _timer_height_retardement = new System.Windows.Forms.Timer();

        int _min_height;
        int _max_height;

        ushort _initial_height;
        /// <summary>
        /// La hauteur initiale du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated height resizing"), DefaultValue(0), Description("La hauteur initiale du controle.")]
        public ushort InitialHeight { get { return _initial_height; } set { _initial_height = value; RefreshMaxMinHeightValues(); } }

        ushort _final_height;
        /// <summary>
        /// La hauteur finale du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated height resizing"), DefaultValue(0), Description("La hauteur finale du controle.")]
        public ushort FinalHeight { get { return _final_height; } set { _final_height = value; RefreshMaxMinHeightValues(); } }

        ushort _height_expansion_interval;
        /// <summary>
        /// L'intervalle d'expansion de la hauteur du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated height resizing"), DefaultValue(1), Description("L'intervalle d'expansion de la hauteur du controle.")]
        public ushort HeightExpansionInterval { get { return _height_expansion_interval; } set { _height_expansion_interval = value; } }

        ushort _height_contraction_interval;
        /// <summary>
        /// L'intervalle de contraction de la hauteur du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated height resizing"), DefaultValue(1), Description("L'intervalle de contraction de la hauteur du controle.")]
        public ushort HeightContractionInterval { get { return _height_contraction_interval; } set { _height_contraction_interval = value; } }

        /// <summary>
        /// L'intervalle du temps entre chaque expansion de la hauteur du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated height resizing"), DefaultValue(1), Description("L'intervalle du temps entre chaque expansion de la hauteur du controle.")]
        public ushort TimerIntervalForHeightExpansion { get { return (ushort)_timer_height_expansion.Interval; } set { _timer_height_expansion.Interval = value > 0 ? value : 1; } }

        /// <summary>
        /// L'intervalle du temps entre chaque contraction de la hauteur du controle.
        /// </summary>
        [Browsable(true), Category("TacosCode: Parameters for animated height resizing"), DefaultValue(1), Description("L'intervalle du temps entre chaque contraction de la hauteur du controle.")]
        public ushort TimerIntervalForHeightContraction { get { return (ushort)_timer_height_contraction.Interval; } set { _timer_height_contraction.Interval = value > 0 ? value : 1; } }

        void RefreshMaxMinHeightValues()
        {
            if (_initial_height < _final_height)
            {
                _max_height = _final_height;
                _min_height = _initial_height;
            }
            else
            {
                _max_height = _initial_height;
                _min_height = _final_height;
            }
            if( Control!=null)
                this.Control.Height = _initial_height;
        }

        /// <summary>
        /// Set parameters for animated height resizing.
        /// </summary>
        /// <param name="initialeHeight">La hauteur initiale du controle.</param>
        /// <param name="finaleHeight">La hauteur finale du controle.</param>
        /// <param name="heightExpansionInterval">L'intervalle d'expansion de la hauteur du controle.</param>
        /// <param name="heightContractionInterval">L'intervalle de contraction de la hauteur du controle.</param>
        /// <param name="timerIntervalForHeightExpansion">L'intervalle du temps entre chaque expansion de la hauteur du controle.</param>
        /// <param name="timerIntervalForHeightContraction">L'intervalle du temps entre chaque contraction de la hauteur du controle.</param>
        public void SetHightResizeParameters(ushort initialeHeight = 0, ushort finaleHeight = 10, ushort heightExpansionInterval = 10,
            ushort heightContractionInterval = 10, ushort timerIntervalForHeightExpansion = 10, ushort timerIntervalForHeightContraction = 10)
        {
            try
            {
                InitialHeight = initialeHeight;
                FinalWidth = finaleHeight;

                HeightContractionInterval = heightContractionInterval;
                HeightExpansionInterval = heightExpansionInterval;

                TimerIntervalForHeightExpansion = timerIntervalForHeightExpansion;
                TimerIntervalForHeightContraction = timerIntervalForHeightContraction;

            }
            catch (Exception x) { Msg.Show(x); }
        }


        void Timer_height_expanding_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Control.Height < _max_height) this.Control.Height += _height_expansion_interval;
                else if (this.Control.Height >= _max_height) { this.Control.Height = _max_height; StopHightResizing(); }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        void Timer_height_reducing_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.Control.Height > _min_height && this.Control.Height - _height_contraction_interval > 0) this.Control.Height -= _height_contraction_interval;
                else { this.Control.Height = _min_height; StopHightResizing(); }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        bool heightPasse;
        void Timer_height_retarding_resize_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!heightPasse)
                {
                    ContractHeight();
                    StopTimerRetardingHightResize();
                }
                else heightPasse = true;
            }
            catch (Exception x) { Msg.Show(x); }
        }


        void StopHightResizing()
        {
            try
            {
                _timer_height_contraction.Stop();
                _timer_height_contraction.Dispose();

                _timer_height_expansion.Stop();
                _timer_height_expansion.Dispose();
            }
            catch (Exception x) { Msg.Show(x); }
        }

        void StopTimerRetardingHightResize()
        {
            try
            {
                _timer_height_retardement.Stop();
                _timer_height_retardement.Dispose();
            }
            catch (Exception x) { Msg.Show(x); }
        }


        /// <summary>
        /// Expansion de la hauteur du controle.
        /// </summary>
        public void ExpandHight()
        {
            try
            {
                if (this.Control != null)
                {
                    dock = Control.Dock.ToString();
                    if (!dock.Contains("Left") && !dock.Contains("Right") && !dock.Contains("Fill"))
                    {
                        StopHightResizing();
                        _timer_height_expansion.Start();
                    }
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        /// <summary>
        /// Contraction de la hauteur du controle.
        /// </summary>
        public void ContractHeight()
        {
            try
            {
                if (this.Control != null)
                {
                    if (!dock.Contains("Left") && !dock.Contains("Right") && !dock.Contains("Fill"))
                    {
                        StopHightResizing();
                        _timer_height_contraction.Start();
                    }
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        /// <summary>
        /// Expansion pui contraction la hauteur du controle.
        /// </summary>
        public void ExpandAndReduceHeight(ushort retardementInterval = 1000)
        {
            try
            {
                _timer_height_retardement.Interval = retardementInterval > 0 ? retardementInterval : 1;
                heightPasse = false;
                ExpandHight();
                _timer_height_retardement.Start();
            }
            catch (Exception x) { Msg.Show(x); }
        }

        /// <summary>
        /// Expansion ou contraction la hauteur du controle.
        /// </summary>
        public void ExpandORReduceHeight()
        { 
            if (this.Control.Height == _max_height) ContractHeight();
            else ExpandHight(); 
        }

        /// <summary>
        /// Retourne true si la hauteur du controle et actuellement au maximale. 
        /// </summary>
        public bool IfCurrentResizeStateHightIsExpanding() 
        { 
            return this.Control.Height == _max_height; 
        }

        #endregion Settings for resizing height controle increasingly


        #region Auto resize

        bool _auto_resize_muse_in = false;
        /// <summary>
        /// Redimension auto du controle une fois le pointeur de la sourie se place dans ce dernier.
        /// </summary>
        [Browsable(true), Category("TacosCode: Auto resize"), DefaultValue(false), Description("Redimension auto du controle une fois le pointeur de la sourie se place dans ce dernier.")]
        public bool AutoResizeMouseIn { get { return this._auto_resize_muse_in; } set { this._auto_resize_muse_in = value; } }


        void Auto_resize_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (AutoResizeMouseIn)
                {
                    ExpandWidth();
                    ExpandHight();
                }       
            }
            catch (Exception x) { Msg.Show(x); }
        }

        void Auto_resize_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (AutoResizeMouseIn)
                {
                    ContractWidth();
                    ContractHeight();
                }                    
            }
            catch (Exception x) { Msg.Show(x); }
        }

        string dock = "";
        void Controle_DockChanged(object sender, EventArgs e)
        {
            this.dock = Control.Dock.ToString();
        }

        #endregion Auto resize

    }

}
