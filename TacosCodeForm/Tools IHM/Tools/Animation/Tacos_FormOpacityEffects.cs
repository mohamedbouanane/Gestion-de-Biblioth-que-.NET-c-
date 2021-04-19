using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace IHM.Components.Animation
{

    // A corriger et tester. 

    /// <summary>
    /// Permet d'appliquer un effet d'apparition et de disparition 
    /// dégradée sur un formulaire en cas d'appel aux méthodes
    /// (Show | Close | Hide | Exite) de cette classe.
    /// </summary>
    public class TacosCode_FormOpacityEffects : Component
    {
        #region Constructors

        public TacosCode_FormOpacityEffects()
        {
            SetDefaultParameters();
            InitialOpacity = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetForm"></param>
        /// <param name="initialOpacity"></param>
        /// <param name="maxOpacity"></param>
        /// <param name="timerIntervalShowForm"></param>
        /// <param name="timerIntervalCloseForm"></param>
        /// <param name="intervalOpacity"></param>
        public TacosCode_FormOpacityEffects(Form targetForm, float initialOpacity = 0, float maxOpacity = 1,
            int timerIntervalShowForm = 1, int timerIntervalCloseForm = 1, float intervalOpacity = 0.025f)
        {
            try
            {
                this.TargetForm = targetForm;
                SetDefaultParameters();

                InitialOpacity = initialOpacity;
                MaxOpacity = maxOpacity;
                IntervalOpacity = intervalOpacity;

                if (targetForm != null) this.TargetForm.Opacity = initialOpacity;

                timer_show_form.Interval = timerIntervalShowForm;
                timer_close_form.Interval = timerIntervalCloseForm;
                timer_exite_form.Interval = timerIntervalCloseForm;
                timer_hide_form.Interval = timerIntervalCloseForm;

            }
            catch (Exception x) { Msg.Show(x); }
        }

        #endregion Constructors


        #region Parameters

        void SetDefaultParameters()
        {
            if (TargetForm != null)
            {
                TargetForm.FormClosing += new FormClosingEventHandler(Form_Shown);
                TargetForm.Shown += new System.EventHandler(Form_Shown);
            }

            timer_show_form.Tick += new System.EventHandler(Timer_show_form_Tick);
            timer_close_form.Tick += new System.EventHandler(Timer_close_form_Tick);
            timer_exite_form.Tick += new System.EventHandler(Timer_exite_form_Tick);
            timer_hide_form.Tick += new System.EventHandler(Timer_hide_form_Tick);
        }


        Form form = null;
        /// <summary>
        /// Le formulaire ciblée.
        /// </summary>
        [Browsable(true), Category("TacosCode: Form opacity parameters"), DefaultValue(null), Description("Le formulaire ciblée.")]
        public Form TargetForm { get { return form; } set { form = value; } }

        float _initial_opacity = 0;
        /// <summary>
        /// L'opacité initiale du formulaire.
        /// </summary>
        [Browsable(true), Category("TacosCode: Form opacity parameters"), DefaultValue(0), Description("L'opacité initiale du formulaire.")]
        public float InitialOpacity { get { return _initial_opacity; } set { _initial_opacity = value < 0 ? 0 : _initial_opacity = value > 1 ? 1 : value; if (TargetForm != null) TargetForm.Opacity = _initial_opacity; } }

        float _interval_opacity = 0.025f;
        /// <summary>
        /// L'intervale d'apparition de formulaire.
        /// </summary>
        [Browsable(true), Category("TacosCode: Form opacity parameters"), DefaultValue(0.025f), Description(".")]
        public float IntervalOpacity { get { return _interval_opacity; } set { _interval_opacity = value; } }


        float _max_opacity = 1;
        /// <summary>
        /// L'opacité maximale du formulaire.
        /// </summary>
        [Browsable(true), Category("TacosCode: Form opacity parameters"), DefaultValue(1), Description(".")]
        public float MaxOpacity { get { return _max_opacity; } set { _max_opacity = value > 1 ? 1 : _max_opacity = value < 0 ? 0 : value; } }

        int _timer_interval_close_form = 1;
        /// <summary>
        /// L'intervalle de férméture du formulaire.
        /// </summary>
        [Browsable(true), Category("TacosCode: Interval view parameters"), DefaultValue(1), Description(".")]
        public int TimerIntervalCloseForm { get { return _timer_interval_close_form; } set { _timer_interval_close_form = value; } }


        int _timer_interval_show_form = 1;
        /// <summary>
        /// L'intervalle d'ouverture du formulaire.
        /// </summary>
        [Browsable(true), Category("TacosCode: Interval view parameters"), DefaultValue(1), Description(".")]
        public int TimerIntervalShowForm { get { return _timer_interval_show_form; } set { timer_show_form.Interval = _timer_interval_show_form = value <= 0 ? 1 : value; } }

        #endregion Parameters


        #region Form Event


        private void Form_Shown(object sender, EventArgs e)
        {
            //Show();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            //Close();
        }

        #endregion Form Event


        #region Timer Event

        Timer timer_show_form = new Timer();
        Timer timer_close_form = new Timer();
        Timer timer_exite_form = new Timer();
        Timer timer_hide_form = new Timer();

        private void Timer_show_form_Tick(object sender, EventArgs e)
        {
            try
            {
                //Msg.Show(TargetForm.Opacity);
                if (TargetForm.Opacity < MaxOpacity) TargetForm.Opacity += IntervalOpacity;
                else { TargetForm.Opacity = 1; TargetForm.Visible = true; StopEffects(); }

            }
            catch (Exception x) { Msg.Show(x); }
        }

        private void Timer_close_form_Tick(object sender, EventArgs e)
        {
            try
            {
                if (TargetForm.Opacity > 0.0) TargetForm.Opacity -= IntervalOpacity;
                else { TargetForm.Close(); StopEffects(); }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        private void Timer_exite_form_Tick(object sender, EventArgs e)
        {
            try
            {
                if (TargetForm.Opacity > 0.0) TargetForm.Opacity -= IntervalOpacity;
                else { StopEffects(); Application.Exit(); }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        private void Timer_hide_form_Tick(object sender, EventArgs e)
        {
            try
            {
                if (TargetForm.Opacity > 0.0) TargetForm.Opacity -= IntervalOpacity;
                else { TargetForm.Hide(); StopEffects(); }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        #endregion Timer Event


        #region Actions

        void StopEffects()
        {
            timer_show_form.Stop();
            timer_show_form.Dispose();

            timer_close_form.Stop();
            timer_close_form.Dispose();

            timer_exite_form.Stop();
            timer_exite_form.Dispose();

            timer_hide_form.Stop();
            timer_hide_form.Dispose();
        }

        /// <summary>
        /// Ouvre graduellement le Fromumaire.
        /// </summary>
        public void Show()
        {
            try
            {
                if (TargetForm != null)
                {
                    StopEffects();
                    //TargetForm.Visible = true;
                    timer_show_form.Start();
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        /// <summary>
        /// Ferme graduellement le formulaire.
        /// </summary>
        public void Close()
        {
            try
            {
                if (TargetForm != null)
                {
                    StopEffects();
                    timer_close_form.Start();
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        /// <summary>
        /// Cache graduellement le formulaire.
        /// </summary>
        public void Hide()
        {
            try
            {
                if (TargetForm != null)
                {
                    StopEffects();
                    timer_hide_form.Start();
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        /// <summary>
        /// Quitte graduellement l'application.
        /// </summary>
        public void Exite()
        {
            try
            {
                if (TargetForm != null)
                {
                    StopEffects();
                    timer_exite_form.Start();
                }
            }
            catch (Exception x) { Msg.Show(x); }
        }

        #endregion Actions

    }
}
