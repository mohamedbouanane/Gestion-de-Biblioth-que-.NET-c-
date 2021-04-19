using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Input = System.Windows.Input;

/// <summary>
/// 
/// </summary>
[RefreshProperties(RefreshProperties.All)]
public class ScrollBarEnhanced : UserControl
{

    #region Private fields

    private Input.MouseButtonState MouseUpDownStatus = Input.MouseButtonState.Released;
    EnhancedScrollBarMouseLocation MouseScrollBarArea = EnhancedScrollBarMouseLocation.OutsideScrollBar;
    private int MouseRelativeYFromThumbTop = 0;
    private decimal PrevouslyReportedHotValue = -1;
    private decimal HotValue = -1;
    private decimal PreviousValue = -1;
    private decimal m_Minimum = 0;
    private decimal m_Maximum = 100;
    private decimal m_Value = 0;
    private ToolTip toolTip1;
    private Timer timerMouseDownRepeater;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem scrollHereToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem topToolStripMenuItem;
    private ToolStripMenuItem bottomToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem2;
    private ToolStripMenuItem pageUpToolStripMenuItem;
    private ToolStripMenuItem pageDownToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem3;
    private ToolStripMenuItem scrollUpToolStripMenuItem;
    private ToolStripMenuItem scrollDownToolStripMenuItem;
    private Orientation m_Orientation = Orientation.Vertical;

    //Every time mouse is pressed down this is populated to be used by the repeat timer
    MouseEventArgs m_MouseDownArgs = null;

    #endregion

    #region Public Events

    /// <summary>
    /// Fires every time mouse is clicked over track area.
    /// </summary>
    [Description("Fires every time mouse is clicked over track area.")]
    public new event EventHandler<EnhancedMouseEventArgs> MouseClick = null;

    /// <summary>
    /// Fires every time mouse moves over track area.
    /// </summary>
    [Description("Fires every time mouse moves over track area.")]
    public new event EventHandler<EnhancedMouseEventArgs> MouseMove = null;

    /// <summary>
    /// Occurs each time scrollbar orientation has changed.
    /// </summary>
    [Description("Occurs each time scrollbar orientation has changed.")]
    public event EventHandler OrientationChanged = null;

    /// <summary>
    /// Occurs every time scrollbar orientation is about to change.
    /// </summary>
    [Description("Occurs every time scrollbar orientation is about to change.")]
    public event EventHandler<CancelEventArgs> OrientationChanging = null;

    /// <summary>
    /// 
    /// </summary>
    public new event EventHandler<EnhancedScrollEventArgs> Scroll = null;

    /// <summary>
    /// Fired every time mouse moves over bookmark (or multiple bookmarks).
    /// Allows to overwrite default ToolTip value.
    /// </summary>
    [Description("Allows to overwrite default ToolTip value.")]
    public event EventHandler<TooltipNeededEventArgs> ToolTipNeeded = null;

    /// <summary>
    /// Fired every time <c>Value</c> of the ScrollBar changes.
    /// </summary>
    [Description("Occurs every time scrollbar value changes.")]
    public event EventHandler ValueChanged = null;

    #endregion

    #region Constructor and related

    /// <summary>
    /// Constructor. Initialize properties.
    /// </summary>
    public ScrollBarEnhanced()
    {
        InitializeComponent();
        SetStyle(ControlStyles.ResizeRedraw, true);
        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.DoubleBuffer, true);
        //Initialize default values for properties
        InitialDelay = 400;
        RepeatRate = 62;
        LargeChange = 10;
        SmallChange = 1;
        timerMouseDownRepeater.Tick += new EventHandler(TimerMouseDownRepeater_Tick);
        Dock = DockStyle.None;
        ClientSize = new Size(SystemInformation.VerticalScrollBarWidth, ClientSize.Height);
        Width = SystemInformation.VerticalScrollBarWidth;
        Orientation = Orientation.Vertical;
    }

    /// <summary>
    /// Generates repeat events when mouse is pressed and hold.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TimerMouseDownRepeater_Tick(object sender, EventArgs e)
    {
        base.OnMouseDown(m_MouseDownArgs);
        DoMouseDown(m_MouseDownArgs);
        if (timerMouseDownRepeater.Enabled == true)
            timerMouseDownRepeater.Interval = RepeatRate;
        else
            timerMouseDownRepeater.Interval = InitialDelay;
        //Do this only if not dragging thumb
        if (MouseScrollBarArea != EnhancedScrollBarMouseLocation.Thumb)
            timerMouseDownRepeater.Enabled = true;
        else
            timerMouseDownRepeater.Enabled = false;
    }

    private IContainer components;
    private void InitializeComponent()
    {
        components = new Container();
        toolTip1 = new ToolTip(components);
        timerMouseDownRepeater = new Timer(components);
        contextMenuStrip1 = new ContextMenuStrip(components);
        scrollHereToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripSeparator();
        topToolStripMenuItem = new ToolStripMenuItem();
        bottomToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem2 = new ToolStripSeparator();
        pageUpToolStripMenuItem = new ToolStripMenuItem();
        pageDownToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem3 = new ToolStripSeparator();
        scrollUpToolStripMenuItem = new ToolStripMenuItem();
        scrollDownToolStripMenuItem = new ToolStripMenuItem();
        contextMenuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
        scrollHereToolStripMenuItem,
        toolStripMenuItem1,
        topToolStripMenuItem,
        bottomToolStripMenuItem,
        toolStripMenuItem2,
        pageUpToolStripMenuItem,
        pageDownToolStripMenuItem,
        toolStripMenuItem3,
        scrollUpToolStripMenuItem,
        scrollDownToolStripMenuItem});
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(153, 198);
        // 
        // scrollHereToolStripMenuItem
        // 
        scrollHereToolStripMenuItem.Name = "scrollHereToolStripMenuItem";
        scrollHereToolStripMenuItem.Size = new Size(152, 22);
        scrollHereToolStripMenuItem.Text = "Scroll Here";
        scrollHereToolStripMenuItem.Click += new EventHandler(ScrollHereToolStripMenuItem_Click);
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(149, 6);
        // 
        // topToolStripMenuItem
        // 
        topToolStripMenuItem.Name = "topToolStripMenuItem";
        topToolStripMenuItem.Size = new Size(152, 22);
        topToolStripMenuItem.Text = "Top";
        topToolStripMenuItem.Click += new EventHandler(TopToolStripMenuItem_Click);
        // 
        // bottomToolStripMenuItem
        // 
        bottomToolStripMenuItem.Name = "bottomToolStripMenuItem";
        bottomToolStripMenuItem.Size = new Size(152, 22);
        bottomToolStripMenuItem.Text = "Bottom";
        bottomToolStripMenuItem.Click += new EventHandler(BottomToolStripMenuItem_Click);
        // 
        // toolStripMenuItem2
        // 
        toolStripMenuItem2.Name = "toolStripMenuItem2";
        toolStripMenuItem2.Size = new Size(149, 6);
        // 
        // pageUpToolStripMenuItem
        // 
        pageUpToolStripMenuItem.Name = "pageUpToolStripMenuItem";
        pageUpToolStripMenuItem.Size = new Size(152, 22);
        pageUpToolStripMenuItem.Text = "Page Up";
        pageUpToolStripMenuItem.Click += new EventHandler(PageUpToolStripMenuItem_Click);
        // 
        // pageDownToolStripMenuItem
        // 
        pageDownToolStripMenuItem.Name = "pageDownToolStripMenuItem";
        pageDownToolStripMenuItem.Size = new Size(152, 22);
        pageDownToolStripMenuItem.Text = "Page Down";
        pageDownToolStripMenuItem.Click += new EventHandler(PageDownToolStripMenuItem_Click);
        // 
        // toolStripMenuItem3
        // 
        toolStripMenuItem3.Name = "toolStripMenuItem3";
        toolStripMenuItem3.Size = new Size(149, 6);
        // 
        // scrollUpToolStripMenuItem
        // 
        scrollUpToolStripMenuItem.Name = "scrollUpToolStripMenuItem";
        scrollUpToolStripMenuItem.Size = new Size(152, 22);
        scrollUpToolStripMenuItem.Text = "Scroll Up";
        scrollUpToolStripMenuItem.Click += new EventHandler(ScrollUpToolStripMenuItem_Click);
        // 
        // scrollDownToolStripMenuItem
        // 
        scrollDownToolStripMenuItem.Name = "scrollDownToolStripMenuItem";
        scrollDownToolStripMenuItem.Size = new Size(152, 22);
        scrollDownToolStripMenuItem.Text = "Scroll Down";
        scrollDownToolStripMenuItem.Click += new EventHandler(ScrollDownToolStripMenuItem_Click);
        // 
        // ScrollBarEnhanced
        // 
        ContextMenuStrip = contextMenuStrip1;
        Name = "ScrollBarEnhanced";
        contextMenuStrip1.ResumeLayout(false);
        ResumeLayout(false);
    }

    /// <summary>
    /// Dispose overridden method. When called from the host <c>disposing</c> parameter is <b>true</b>.
    /// When called from the finalize parameter is <b>false</b>.
    /// </summary>
    /// <param name="disposing"></param>
    protected override void Dispose(bool disposing)
    {
        if (disposing == true)
            if (components != null)
            {
                toolTip1.Dispose();
                timerMouseDownRepeater.Dispose();
                contextMenuStrip1.Dispose();
                scrollHereToolStripMenuItem.Dispose();
                toolStripMenuItem1.Dispose();
                topToolStripMenuItem.Dispose();
                bottomToolStripMenuItem.Dispose();
                toolStripMenuItem2.Dispose();
                pageUpToolStripMenuItem.Dispose();
                pageDownToolStripMenuItem.Dispose();
                toolStripMenuItem3.Dispose();
                scrollUpToolStripMenuItem.Dispose();
                scrollDownToolStripMenuItem.Dispose();
                components.Dispose();
            }
        base.Dispose(disposing);
    }

    #endregion

    #region Public Properties

    /// <summary>
    /// Delay in milliseconds to start autorepeat behavior when mouse is pressed down and hold.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(400), Category("Enhanced")]
    [Description("Delay in milliseconds to start autorepeat behavior when mouse is pressed down and hold.")]
    public int InitialDelay { set; get; }

    /// <summary>
    /// Large scrollbar change.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(10), Category("Enhanced")]
    [Description("Large scrollbar change.")]
    public decimal LargeChange { set; get; }

    /// <summary>
    /// "Maximum scrollbar value.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(100), Category("Enhanced")]
    [Description("Maximum scrollbar value.")]
    public decimal Maximum
    {
        get { return m_Maximum; }
        set
        {
            if (value < Minimum)
                throw new ArgumentException("Minimum has to be less or equal Maximum", "Minimum");
            //The following line will throw exception is range is more than decimal.MaxValue
            m_Maximum = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Minimum scrollbar value.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(0), Category("Enhanced")]
    [Description("Minimum scrollbar value.")]
    public decimal Minimum
    {
        get { return m_Minimum; }
        set
        {
            if (Maximum < value)
                throw new ArgumentException("Minimum has to be less or equal Maximum", "Minimum");
            //The following line will throw exception is range is more than decimal.MaxValue
            m_Minimum = value;
            Invalidate();
        }
    }

    /// <summary>
    /// ScrollBar orientation.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(Orientation.Vertical), Category("Enhanced")]
    [Description("ScrollBar orientation.")]
    public Orientation Orientation
    {
        set
        {
            if (OrientationChanging != null)
            {
                CancelEventArgs ea = new CancelEventArgs(false);
                OrientationChanging(this, ea);
                if (ea.Cancel == true)
                    return;
            }
            if (m_Orientation != value)
            {
                m_Orientation = value;
                //Switch width with height
                int tmpWidth = Width;
                Width = Height;
                Height = tmpWidth;
                if (Orientation == Orientation.Vertical)
                {
                    base.MinimumSize = new Size(0, 2 * SystemInformation.VerticalScrollBarArrowHeight + ThumbLength);
                    switch (Dock)
                    {
                        case DockStyle.Bottom:
                            Dock = DockStyle.Right; break;
                        case DockStyle.Top:
                            Dock = DockStyle.Left; break;
                    }
                }
                else
                {
                    base.MinimumSize = new Size(2 * SystemInformation.HorizontalScrollBarArrowWidth + ThumbLength, 0);
                    switch (Dock)
                    {
                        case DockStyle.Right:
                            Dock = DockStyle.Bottom; break;
                        case DockStyle.Left:
                            Dock = DockStyle.Top; break;
                    }
                }
                OrientationChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        get
        {
            return m_Orientation;
        }
    }

    /// <summary>
    /// Delay in milliseconds between autorepeat MouseDown events when mouse is pressed down and hold.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(62), Category("Enhanced")]
    [Description("Delay in milliseconds between autorepeat MouseDown events when mouse is pressed down and hold.")]
    public int RepeatRate { set; get; }

    /// <summary>
    /// When set to <b>true</b>, allows to show ToolTip when mouse moves over scrollbar area.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Enhanced")]
    [Description("When set to 'true', allows to show ToolTip when mouse moves over scrollbar area.")]
    public bool ShowTooltipOnMouseMove { set; get; }

    /// <summary>
    /// Small bookmark change.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(1), Category("Enhanced")]
    [Description("Small change.")]
    public decimal SmallChange { set; get; }

    /// <summary>
    /// Bookmark value. Determines current thumb position.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(0), Category("Enhanced")]
    [Description("Value")]
    public decimal Value
    {
        get { return m_Value; }
        set
        {
            if (value < Minimum)
                m_Value = Minimum;
            else if (value > Maximum)
                m_Value = Maximum;
            else
                m_Value = value;
            OnValueChanged();
            Invalidate();
        }
    }

    #endregion

    #region Overridden events

    /// <summary>
    /// What should happen here:
    /// 1. Save information that mouse is down
    /// 2. Call timer event handler (it will repeat periodically MouseDown events as long as mouse is down)
    /// </summary>
    /// <param name="e">Standard <c>MouseEventArgs</c>.</param>
    protected override void OnMouseDown(MouseEventArgs e)
    {
        //Save arguments passed to mouse down
        m_MouseDownArgs = e;
        MouseUpDownStatus = Input.MouseButtonState.Pressed;
        //Make sure timer is disabled
        timerMouseDownRepeater.Enabled = false;
        //Call timer event; it will call DoMouseDown every RepeatRate interval
        TimerMouseDownRepeater_Tick(null, EventArgs.Empty);
    }

    /// <summary>
    /// This private methods called from repeater timer event handler
    /// </summary>
    /// <param name="e"></param>
    private void DoMouseDown(MouseEventArgs e)
    {
        // Save scrollbar area where mouse was pressed 
        if (Orientation == Orientation.Vertical)
            MouseScrollBarArea = MouseLocation(e.Y, out MouseRelativeYFromThumbTop);
        else
            MouseScrollBarArea = MouseLocation(e.X, out MouseRelativeYFromThumbTop);
        // Calculate ScrollEvent arguments and adjust Value if needed
        decimal NewValue = Value;
        ScrollEventType et;
        switch (MouseScrollBarArea)
        {
            case EnhancedScrollBarMouseLocation.BottomOrRightArrow:
            case EnhancedScrollBarMouseLocation.BottomOrRightTrack:
                if (MouseScrollBarArea == EnhancedScrollBarMouseLocation.BottomOrRightArrow)
                {
                    NewValue += SmallChange;
                    et = ScrollEventType.SmallIncrement;
                }
                else    // EnhancedScrollBarMouseLocation.bottomTrack
                {
                    NewValue += LargeChange;
                    et = ScrollEventType.LargeIncrement;
                }
                if (NewValue >= Maximum)
                {
                    NewValue = Maximum;
                    et = ScrollEventType.Last;
                }
                OnScroll(NewValue, Value, et);
                break;
            case EnhancedScrollBarMouseLocation.Thumb:
                OnScroll(Value, Value, ScrollEventType.ThumbTrack);
                break;
            case EnhancedScrollBarMouseLocation.TopOrLeftArrow:
            case EnhancedScrollBarMouseLocation.TopOrLeftTrack:
                if (MouseScrollBarArea == EnhancedScrollBarMouseLocation.TopOrLeftArrow)
                {
                    NewValue -= SmallChange;
                    et = ScrollEventType.SmallDecrement;
                }
                else
                {
                    NewValue -= LargeChange;
                    et = ScrollEventType.LargeIncrement;
                }
                if (NewValue <= Minimum)
                {
                    NewValue = Minimum;
                    et = ScrollEventType.First;
                }
                OnScroll(NewValue, Value, et);
                break;
        }
        Value = NewValue;
        //4 Repaint
        Invalidate();
    }

    /// <summary>
    /// Captures mouse wheel actions and translates them to small decrement events.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseWheel(MouseEventArgs e)
    {
        int ScrollStep = e.Delta / Input.Mouse.MouseWheelDeltaForOneLine;
        //Calculate new value
        decimal NewValue = Value - SmallChange * ScrollStep;
        if (NewValue < Value)
            OnScroll(NewValue, Value, ScrollEventType.SmallDecrement);
        else
            OnScroll(NewValue, Value, ScrollEventType.SmallIncrement);
        Value = NewValue;
        OnScroll(Value, Value, ScrollEventType.EndScroll);
        base.OnMouseWheel(e);
    }

    /// <summary>
    /// MouseClick override. Calls MouseClick event handled with enhanced arguments. 
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        //enrich arguments and call back the host
        OnMouseClick(e, Value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        //Mouse is down and is over thumb
        if (MouseUpDownStatus == Input.MouseButtonState.Pressed && MouseScrollBarArea == EnhancedScrollBarMouseLocation.Thumb)
        {
            //Calculate Value based on new e.Y 
            decimal NewValue;
            if (Orientation == Orientation.Vertical)
                NewValue = ThumbTopPosition2Value(e.Y - MouseRelativeYFromThumbTop);
            else
                NewValue = ThumbTopPosition2Value(e.X - MouseRelativeYFromThumbTop);
            if (NewValue < Minimum) 
                NewValue = Minimum;
            if (NewValue > Maximum) 
                NewValue = Maximum;
            //Call onScroll event 
            OnScroll(NewValue, Value, ScrollEventType.ThumbTrack);
            //Assign new value
            Value = NewValue;  //New value will move scrollbar to proper position
            //Refresh display
            Invalidate();
        }
        else
        {
            string toolTip = string.Empty;
            // Save current (before mouse move) mouse location
            EnhancedScrollBarMouseLocation oldLocation = MouseScrollBarArea;
            int TrackPosition; ;
            EnhancedScrollBarMouseLocation newLocation;
            if (Orientation == Orientation.Vertical)
            {
                newLocation = MouseLocation(e.Y, out int tmpInt);
                TrackPosition = e.Y - SystemInformation.VerticalScrollBarArrowHeight;
                switch (newLocation)
                {
                    case EnhancedScrollBarMouseLocation.TopOrLeftArrow:
                        TrackPosition = 0;
                        break;
                    case EnhancedScrollBarMouseLocation.BottomOrRightArrow:
                        TrackPosition = ClientSize.Height - 2 * SystemInformation.VerticalScrollBarArrowHeight;
                        break;
                }
            }
            else
            {
                newLocation = MouseLocation(e.X, out int tmpInt);
                TrackPosition = e.X - SystemInformation.VerticalScrollBarArrowHeight;
                switch (newLocation)
                {
                    case EnhancedScrollBarMouseLocation.TopOrLeftArrow:
                        TrackPosition = 0;
                        break;
                    case EnhancedScrollBarMouseLocation.BottomOrRightArrow:
                        TrackPosition = ClientSize.Width - 2 * SystemInformation.HorizontalScrollBarArrowWidth;
                        break;
                }
            }
            HotValue = (Maximum - Minimum) * ((decimal)TrackPosition / TrackLength) + Minimum;
            MouseScrollBarArea = newLocation;
            if (TrackPosition < 0 || TrackPosition > TrackLength)
                toolTip1.Hide(this);
            else
            {
                if (PrevouslyReportedHotValue != HotValue)
                {
                    PrevouslyReportedHotValue = HotValue;
                    string defaultToolTip = Name + " " + HotValue.ToString("###,##0");
                    if (ToolTipNeeded != null)
                    {
                        TooltipNeededEventArgs ea = new TooltipNeededEventArgs(HotValue, defaultToolTip);
                        ToolTipNeeded(this, ea);
                        toolTip = ea.ToolTip;
                    }
                    else  //display default value ToolTip
                    {
                        toolTip = defaultToolTip;
                    }
                    if (toolTip1.GetToolTip(this) != toolTip)
                        toolTip1.SetToolTip(this, toolTip);
                }
                //Call the host to notify about the MouseMove event		
                OnMouseMove(e, HotValue);
                //If moving over different area- refresh display
                if (oldLocation != MouseScrollBarArea)
                    Invalidate();
            }
        }
    }

    /// <summary>
    /// Forces repaint of ScrollBar when mouse moves outside of ScrollBar area.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseLeave(EventArgs e)
    {
        MouseUpDownStatus = Input.MouseButtonState.Released;
        MouseScrollBarArea = EnhancedScrollBarMouseLocation.OutsideScrollBar;
        timerMouseDownRepeater.Enabled = false;
        base.OnMouseLeave(e);
        Invalidate();
    }

    /// <summary>
    /// Fires <c>Scroll</c> events and refreshes ScrollBar display.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        timerMouseDownRepeater.Enabled = false;
        MouseUpDownStatus = Input.MouseButtonState.Released;
        switch (MouseScrollBarArea)
        {
            case EnhancedScrollBarMouseLocation.BottomOrRightArrow:
            case EnhancedScrollBarMouseLocation.TopOrLeftArrow:
            case EnhancedScrollBarMouseLocation.BottomOrRightTrack:
            case EnhancedScrollBarMouseLocation.TopOrLeftTrack:
                OnScroll(Value, Value, ScrollEventType.EndScroll);
                break;
            case EnhancedScrollBarMouseLocation.Thumb:
                OnScroll(Value, Value, ScrollEventType.ThumbPosition);
                OnScroll(Value, Value, ScrollEventType.EndScroll);
                break;
        }
        Invalidate();
    }

    #endregion

    #region Private helpers/wrappers of public events

    private void OnValueChanged()
    {
        if (ValueChanged != null && Value != PreviousValue)
        {
            PreviousValue = Value;
            ValueChanged(this, new EventArgs());
        }
    }

    private void OnMouseClick(MouseEventArgs mouseArgs, decimal Value)
    {
        if (MouseClick != null)
        {
            //Call event handler
            //Pass HotValue instead Value.
            //This makes more since since value cannot be examined directly
            //as property of ScrollBarEnhanced
            EnhancedMouseEventArgs e = new EnhancedMouseEventArgs(HotValue, mouseArgs, MouseScrollBarArea);
            MouseClick(this, e);
        }
    }

    private void OnMouseMove(MouseEventArgs ea, decimal HotValue)
    {
        if (MouseMove != null)
        {
            //Call event handler
            EnhancedMouseEventArgs e = new EnhancedMouseEventArgs(HotValue, ea, MouseScrollBarArea);
            MouseMove(this, e);
        }
    }

    private void OnScroll(decimal newVal, decimal oldVal, ScrollEventType scrollEventType)
    {
        if (Scroll != null)
        {
            ScrollOrientation ScrollOrientation;
            if (Orientation == Orientation.Horizontal)
                ScrollOrientation = ScrollOrientation.HorizontalScroll;
            else
                ScrollOrientation = ScrollOrientation.VerticalScroll;
            //Make sure NewVal is within valid range
            newVal = Math.Max(Math.Min(Maximum, newVal), Minimum);
            EnhancedScrollEventArgs ea = new EnhancedScrollEventArgs(oldVal, newVal, scrollEventType, ScrollOrientation);
            Scroll(this, ea);
        }
    }

    #endregion

    #region OnPaint override

    private int ArrowLegth()
    {
        return Orientation == Orientation.Vertical ? SystemInformation.VerticalScrollBarArrowHeight : SystemInformation.HorizontalScrollBarArrowWidth;
    }

    /// <summary>
    /// Overridden OnPaint. Draws all EnhancedScrollBar elements and draws all associated bookmarks.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPaint(PaintEventArgs e)
    {
        //Draw top arrow
        Rectangle rec;
        ScrollBarState state = GetScrollBarAreaState(EnhancedScrollBarMouseLocation.TopOrLeftArrow);
        if (Orientation == Orientation.Vertical)
        {
            rec = new Rectangle(0, 0, ClientSize.Width, ArrowLegth());
            switch (state)
            {
                case ScrollBarState.Disabled:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.UpDisabled);
                    break;
                case ScrollBarState.Pressed:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.UpPressed);
                    break;
                case ScrollBarState.Normal:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.UpNormal);
                    break;
                case ScrollBarState.Hot:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.UpHot);
                    break;
            }
        }
        else
        {
            rec = new Rectangle(0, 0, ArrowLegth(), ClientSize.Height);
            switch (state)
            {
                case ScrollBarState.Disabled:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.LeftDisabled);
                    break;
                case ScrollBarState.Pressed:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.LeftPressed);
                    break;
                case ScrollBarState.Normal:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.LeftNormal);
                    break;
                case ScrollBarState.Hot:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.LeftHot);
                    break;
            }
        }
        //Draw top track
        int ThumbPos = Value2ThumbTopPosition(Value);
        state = GetScrollBarAreaState(EnhancedScrollBarMouseLocation.TopOrLeftTrack);
        if (Orientation == Orientation.Vertical)
        {
            rec = new Rectangle(0, ArrowLegth() + 1, ClientSize.Width, ThumbPos - ArrowLegth());
            ScrollBarRenderer.DrawUpperVerticalTrack(e.Graphics, rec, state);
        }
        else
        {
            rec = new Rectangle(ArrowLegth() + 1, 0, ThumbPos - ArrowLegth(), ClientSize.Height);
            ScrollBarRenderer.DrawLeftHorizontalTrack(e.Graphics, rec, state);
        }
        //draw thumb
        int nThumbLength = ThumbLength;
        DrawThumb(e.Graphics, nThumbLength, ThumbPos);
        //Draw bottom track
        state = GetScrollBarAreaState(EnhancedScrollBarMouseLocation.BottomOrRightTrack);
        if (Orientation == Orientation.Vertical)
        {
            rec = new Rectangle(0, ThumbPos + nThumbLength, ClientSize.Width, TrackLength + ArrowLegth() - (ThumbPos + nThumbLength));
            ScrollBarRenderer.DrawLowerVerticalTrack(e.Graphics, rec, state);
        }
        else
        {
            rec = new Rectangle(ThumbPos + nThumbLength, 0, TrackLength + ArrowLegth() - (ThumbPos + nThumbLength), ClientSize.Height);
            ScrollBarRenderer.DrawRightHorizontalTrack(e.Graphics, rec, state);
        }
        //Draw bottom arrow 
        state = GetScrollBarAreaState(EnhancedScrollBarMouseLocation.BottomOrRightArrow);
        if (Orientation == Orientation.Vertical)
        {
            rec = new Rectangle(0, ClientSize.Height - ArrowLegth(), ClientSize.Width, ArrowLegth());
            switch (state)
            {
                case ScrollBarState.Disabled:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.DownDisabled);
                    break;
                case ScrollBarState.Pressed:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.DownPressed);
                    break;
                case ScrollBarState.Normal:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.DownNormal);
                    break;
                case ScrollBarState.Hot:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.DownHot);
                    break;
            }
        }
        else
        {
            rec = new Rectangle(ClientSize.Width - ArrowLegth(), 0, ArrowLegth(), ClientSize.Height);
            switch (state)
            {
                case ScrollBarState.Disabled:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.RightDisabled);
                    break;
                case ScrollBarState.Pressed:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.RightPressed);
                    break;
                case ScrollBarState.Normal:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.RightNormal);
                    break;
                case ScrollBarState.Hot:
                    ScrollBarRenderer.DrawArrowButton(e.Graphics, rec, ScrollBarArrowButtonState.RightHot);
                    break;
            }
        }
        DrawThumb(e.Graphics, nThumbLength, ThumbPos);
    }

    private void DrawThumb(Graphics graphics, int thumbLength, int thumbPosition)
    {
        ScrollBarState state = GetScrollBarAreaState(EnhancedScrollBarMouseLocation.Thumb);
        Rectangle rec;
        if (Orientation == Orientation.Vertical)
        {
            rec = new Rectangle(0, thumbPosition, ClientSize.Width, thumbLength);
            ScrollBarRenderer.DrawVerticalThumb(graphics, rec, state);
            //draw thumb grip
            if (thumbLength >= SystemInformation.VerticalScrollBarThumbHeight)
                ScrollBarRenderer.DrawVerticalThumbGrip(graphics, rec, ScrollBarState.Normal);
        }
        else
        {
            rec = new Rectangle(thumbPosition, 0, thumbLength, ClientSize.Height);
            ScrollBarRenderer.DrawHorizontalThumb(graphics, rec, state);
            //draw thumb grip
            if (thumbLength >= SystemInformation.HorizontalScrollBarThumbWidth)
                ScrollBarRenderer.DrawHorizontalThumbGrip(graphics, rec, ScrollBarState.Normal);
        }
    }

    private ScrollBarState GetScrollBarAreaState(EnhancedScrollBarMouseLocation mouseHotLocation)
    {
        if (Enabled == true)
        {
            if (MouseScrollBarArea == mouseHotLocation)
                return MouseUpDownStatus == Input.MouseButtonState.Pressed ? ScrollBarState.Pressed : ScrollBarState.Hot;
            else
                return ScrollBarState.Normal;
        }
        else
            return ScrollBarState.Disabled;
    }

    #endregion

    #region private helper methods

    private void NavigateTo(decimal NewValue)
    {
        OnScroll(Value, Value, ScrollEventType.ThumbTrack);
        OnScroll(Value, NewValue, ScrollEventType.ThumbTrack);
        Value = NewValue;
        OnScroll(Value, Value, ScrollEventType.ThumbPosition);
        OnScroll(Value, Value, ScrollEventType.EndScroll);
    }

    private int TrackLength
    {
        get
        {
            if (Orientation == Orientation.Vertical)
                return ClientSize.Height - 2 * SystemInformation.VerticalScrollBarArrowHeight;
            else
                return ClientSize.Width - 2 * SystemInformation.HorizontalScrollBarArrowWidth;
        }
    }

    private int ThumbLength
    {
        get
        {
            if (Minimum == Maximum) 
                return TrackLength;
            int nThumbLength = (int)(TrackLength / (Maximum - Minimum + 1));
            if (Orientation == Orientation.Vertical)
            {
                if (nThumbLength < SystemInformation.VerticalScrollBarThumbHeight)
                    nThumbLength = SystemInformation.VerticalScrollBarThumbHeight;
            }
            else
            {
                if (nThumbLength < SystemInformation.HorizontalScrollBarThumbWidth)
                    nThumbLength = SystemInformation.HorizontalScrollBarThumbWidth;
            }
            return nThumbLength;
        }
    }

    private int Value2ThumbTopPosition(decimal value)
    {
        if (Orientation == Orientation.Vertical)
        {
            if (Maximum == Minimum)
                return SystemInformation.VerticalScrollBarArrowHeight;
            decimal ratio = (decimal)(ClientSize.Height - 2 * SystemInformation.VerticalScrollBarArrowHeight - ThumbLength) / (Maximum - Minimum);
            return (int)((value - Minimum) * ratio) + SystemInformation.VerticalScrollBarArrowHeight;
        }
        else
        {
            if (Maximum == Minimum)
                return SystemInformation.HorizontalScrollBarArrowWidth;
            decimal ratio = (decimal)(ClientSize.Width - 2 * SystemInformation.HorizontalScrollBarArrowWidth - ThumbLength) / (Maximum - Minimum);
            return (int)((value - Minimum) * ratio) + SystemInformation.HorizontalScrollBarArrowWidth;
        }
    }

    private decimal ThumbTopPosition2Value(int y)
    {
        if (Orientation == Orientation.Vertical)
        {
            if (ClientSize.Height - 2 * SystemInformation.VerticalScrollBarArrowHeight - ThumbLength == 0)
                return 0;
            else
            {
                decimal ratio = (decimal)((y - SystemInformation.VerticalScrollBarArrowHeight)) / (ClientSize.Height - 2 * SystemInformation.VerticalScrollBarArrowHeight - ThumbLength);
                return (Maximum - Minimum) * ratio + Minimum;
            }
        }
        else
        {
            if (ClientSize.Width - 2 * SystemInformation.HorizontalScrollBarArrowWidth - ThumbLength == 0)
                return 0;
            else
            {
                decimal ratio = (decimal)((y - SystemInformation.HorizontalScrollBarArrowWidth)) / (ClientSize.Width - 2 * SystemInformation.HorizontalScrollBarArrowWidth - ThumbLength);
                return (Maximum - Minimum) * ratio + Minimum;
            }
        }
    }

    private EnhancedScrollBarMouseLocation MouseLocation(int absolutePosition, out int relativeY)
    {
        if (Orientation == Orientation.Vertical)
        {
            if (absolutePosition <= SystemInformation.VerticalScrollBarArrowHeight)
            {
                relativeY = absolutePosition;
                return EnhancedScrollBarMouseLocation.TopOrLeftArrow;
            }
            else if (absolutePosition > ClientSize.Height - SystemInformation.VerticalScrollBarArrowHeight)
            {
                relativeY = absolutePosition - ClientSize.Height + SystemInformation.VerticalScrollBarArrowHeight;
                return EnhancedScrollBarMouseLocation.BottomOrRightArrow;
            }
            else
            {
                int thumbTop = Value2ThumbTopPosition(Value);
                if (absolutePosition < thumbTop)
                {
                    relativeY = absolutePosition - SystemInformation.VerticalScrollBarArrowHeight;
                    return EnhancedScrollBarMouseLocation.TopOrLeftTrack;
                }
                else if (absolutePosition < thumbTop + ThumbLength)
                {
                    relativeY = absolutePosition - thumbTop;
                    return EnhancedScrollBarMouseLocation.Thumb;
                }
                else
                {
                    relativeY = absolutePosition - thumbTop - ThumbLength;
                    return EnhancedScrollBarMouseLocation.BottomOrRightTrack;
                }
            }
        }
        else
        {
            if (absolutePosition <= SystemInformation.HorizontalScrollBarArrowWidth)
            {
                relativeY = absolutePosition;
                return EnhancedScrollBarMouseLocation.TopOrLeftArrow;
            }
            else if (absolutePosition > ClientSize.Width - SystemInformation.HorizontalScrollBarArrowWidth)
            {
                relativeY = absolutePosition - ClientSize.Width + SystemInformation.HorizontalScrollBarArrowWidth;
                return EnhancedScrollBarMouseLocation.BottomOrRightArrow;
            }
            else
            {
                int thumbTop = Value2ThumbTopPosition(Value);
                if (absolutePosition < thumbTop)
                {
                    relativeY = absolutePosition - SystemInformation.HorizontalScrollBarArrowWidth;
                    return EnhancedScrollBarMouseLocation.TopOrLeftTrack;
                }
                else if (absolutePosition < thumbTop + ThumbLength)
                {
                    relativeY = absolutePosition - thumbTop;
                    return EnhancedScrollBarMouseLocation.Thumb;
                }
                else
                {
                    relativeY = absolutePosition - thumbTop - ThumbLength;
                    return EnhancedScrollBarMouseLocation.BottomOrRightTrack;
                }
            }
        }
    }

    #endregion

    #region Context menu event handlers

    private void TopToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OnScroll(Minimum, Value, ScrollEventType.First);
        Value = Minimum;
        OnScroll(Value, Value, ScrollEventType.EndScroll);
    }

    private void BottomToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OnScroll(Maximum, Value, ScrollEventType.Last);
        Value = Maximum;
        OnScroll(Value, Value, ScrollEventType.EndScroll);
    }

    private void ScrollHereToolStripMenuItem_Click(object sender, EventArgs e)
    {
        NavigateTo(HotValue);
    }

    private void PageUpToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OnScroll(Value - LargeChange, Value, ScrollEventType.LargeDecrement);
        Value -= LargeChange;
        OnScroll(Value, Value, ScrollEventType.EndScroll);
    }

    private void PageDownToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OnScroll(Value + LargeChange, Value, ScrollEventType.LargeIncrement);
        Value += LargeChange;
        OnScroll(Value, Value, ScrollEventType.EndScroll);
    }

    private void ScrollUpToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OnScroll(Value - SmallChange, Value, ScrollEventType.SmallDecrement);
        Value -= SmallChange;
        OnScroll(Value, Value, ScrollEventType.EndScroll);
    }

    private void ScrollDownToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OnScroll(Value + SmallChange, Value, ScrollEventType.SmallIncrement);
        Value += SmallChange;
        OnScroll(Value, Value, ScrollEventType.EndScroll);
    }

    #endregion

}

#region Enhanced event argument definitions

/// <summary>
/// Argument for <c>ToolTipNeeded</c> event.
/// </summary>
public class TooltipNeededEventArgs : EventArgs
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="DecValue">ToolTip value. Hot ToolTip value mouse is moving over.</param>
    /// <param name="StringToolTip">Default ToolTip message.</param>
    public TooltipNeededEventArgs(decimal DecValue, string StringToolTip)
    {
        Value = DecValue;
        ToolTip = StringToolTip;
    }

    /// <summary>
    /// ToolTip value. Hot ToolTip value mouse is moving over.
    /// </summary>
    public decimal Value { private set; get; }

    /// <summary>
    /// Default ToolTip message.
    /// </summary>
    public string ToolTip { set; get; }

}

/// <summary>
/// Arguments for EnhancedScrollEvent.
/// </summary>
public class EnhancedScrollEventArgs : EventArgs
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public EnhancedScrollEventArgs()
    {
        NewValue = 0;
        OldValue = 0;
        Type = ScrollEventType.EndScroll;
        ScrollOrientation = ScrollOrientation.VerticalScroll;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="DEcOldValue">Previous EnhancedScrollBar value.</param>
    /// <param name="DecNewValue">New EnhancedScrollBar value.</param>
    /// <param name="EventTypeScroll">Type of the scroll event.</param>
    /// <param name="OrientationScroll">EnhancedScrollBar orientation.</param>
    public EnhancedScrollEventArgs(decimal DEcOldValue, decimal DecNewValue, ScrollEventType EventTypeScroll, ScrollOrientation OrientationScroll)
    {
        NewValue = DecNewValue;
        OldValue = DEcOldValue;
        ScrollOrientation = OrientationScroll;
        Type = EventTypeScroll;
    }

    /// <summary>
    /// Previous EnhancedScrollBar value.
    /// </summary>
    public decimal OldValue { private set; get; }

    /// <summary>
    /// New EnhancedScrollBar value.
    /// </summary>
    public decimal NewValue { private set; get; }

    /// <summary>
    /// EnhancedScrollBar orientation.
    /// </summary>
    public ScrollOrientation ScrollOrientation { private set; get; }

    /// <summary>
    /// Type of the scroll event.
    /// </summary>
    public ScrollEventType Type { private set; get; }
}

/// <summary>
/// Arguments for mouse related events.
/// </summary>
public class EnhancedMouseEventArgs : MouseEventArgs
{

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="DecValue">ScrollBar <c>Value when event occurred.</c></param>
    /// <param name="MouseArgs">Original <c>MouseArgs</c>.</param>
    /// <param name="SectionScrollBar">Section of the EnhancedScrollBar where mouse pointer is located.</param>
    public EnhancedMouseEventArgs(decimal DecValue, MouseEventArgs MouseArgs, EnhancedScrollBarMouseLocation SectionScrollBar) : base(MouseArgs.Button, MouseArgs.Clicks, MouseArgs.X, MouseArgs.Y, MouseArgs.Delta)
    {
        Value = DecValue;
        ScrollBarSection = SectionScrollBar;
    }

    /// <summary>
    /// ScrollBar <c>Value</c> when event occurred.
    /// </summary>
    public decimal Value { private set; get; }

    /// <summary>
    /// Section of the EnhancedScrollBar where mouse pointer is located.
    /// </summary>
    public EnhancedScrollBarMouseLocation ScrollBarSection { private set; get; }
}

#endregion

#region Public Enumerators

/// <summary>
/// Area of ScrollBar definitions. Used to describe relation of mouse pointer location
/// to the distinct part of ScrollBar.
/// </summary>
public enum EnhancedScrollBarMouseLocation
{
    /// <summary>
    /// Located outside of the ScrollBar.
    /// </summary>
    OutsideScrollBar,

    /// <summary>
    /// Located over top (for vertical ScrollBar) or 
    /// over left hand side arrow (for horizontal ScrollBar).
    /// </summary>
    TopOrLeftArrow,

    /// <summary>
    /// Located over top (for vertical Scrollbar) or
    /// over left hand side track (for horizontal ScrollBar).
    /// Track is the area between arrow and thumb images.
    /// </summary>
    TopOrLeftTrack,

    /// <summary>
    /// Located over ScrollBar thumb. Thumb is movable portion of the ScrollBar.
    /// </summary>
    Thumb,

    /// <summary>
    /// Located over bottom (for vertical Scrollbar) or
    /// over right hand side track (for horizontal ScrollBar).
    /// Track is the area between arrow and thumb images.
    /// </summary>
    BottomOrRightTrack,

    /// <summary>
    /// Located over bottom (for vertical ScrollBar) or 
    /// over right hand side arrow (for horizontal ScrollBar).
    /// </summary>
    BottomOrRightArrow
}

#endregion

