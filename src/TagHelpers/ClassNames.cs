namespace TagHelpers;

public static class ClassNames
{
    /// <summary>
    /// A generic active class name.
    /// </summary>
    public const string Active = "active";

    /// <summary>
    /// A generic disabled class name.
    /// </summary>
    public const string Disabled = "disabled";

    public static class Buttons
    {
        /// <summary>
        /// The default class for buttons.
        /// </summary>
        public const string Button = "btn";

        /// <summary>
        /// The class for outline buttons.
        /// </summary>
        public const string OutlineButton = "btn-outline";

        /// <summary>
        /// The class that styles the button as a link.
        /// </summary>
        public const string LinkButton = "btn-link";

        /// <summary>
        /// The class for close buttons.
        /// </summary>
        public const string Close = "close";

        /// <summary>
        /// The class for large buttons.
        /// </summary>
        public const string Large = "btn-lg";

        /// <summary>
        /// The class for small buttons.
        /// </summary>
        public const string Small = "btn-sm";

        /// <summary>
        /// The class for block-level buttons.
        /// </summary>
        public const string BlockLevel = "btn-block";
    }

    public static class Cols
    {
        public const string Col = "col";
    }

    public static class Containers
    {
        public const string FixedWidth = "container";
        public const string Fluid = "container-fluid";
    }

    public static class Rows
    {
        public const string Row = "row";
        public const string Cols = "row-cols";
        public const string NoGutters = "no-gutters";
    }
}
