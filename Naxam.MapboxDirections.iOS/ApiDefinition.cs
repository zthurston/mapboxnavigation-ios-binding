﻿using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;

namespace MapboxDirections
{
    [Static]
    partial interface MBDirectionsProfileIdentifier
    {
        // extern const MBDirectionsProfileIdentifier MBDirectionsProfileIdentifierAutomobile;
        [Field("MBDirectionsProfileIdentifierAutomobile", "__Internal")]
        NSString Automobile { get; }

        // extern const MBDirectionsProfileIdentifier MBDirectionsProfileIdentifierAutomobileAvoidingTraffic;
        [Field("MBDirectionsProfileIdentifierAutomobileAvoidingTraffic", "__Internal")]
        NSString AutomobileAvoidingTraffic { get; }

        // extern const MBDirectionsProfileIdentifier MBDirectionsProfileIdentifierCycling;
        [Field("MBDirectionsProfileIdentifierCycling", "__Internal")]
        NSString Cycling { get; }

        // extern const MBDirectionsProfileIdentifier MBDirectionsProfileIdentifierWalking;
        [Field("MBDirectionsProfileIdentifierWalking", "__Internal")]
        NSString Walking { get; }
    }

    // @interface MBDirections : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDirections
    {
        // @property (readonly, nonatomic, strong, class) MBDirections * _Nonnull sharedDirections;
        [Static]
        [Export("sharedDirections", ArgumentSemantic.Strong)]
        MBDirections SharedDirections { get; }

        // -(instancetype _Nonnull)initWithAccessToken:(NSString * _Nullable)accessToken host:(NSString * _Nullable)host __attribute__((objc_designated_initializer));
        [Export("initWithAccessToken:host:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string accessToken, [NullAllowed] string host);

        // -(instancetype _Nonnull)initWithAccessToken:(NSString * _Nullable)accessToken;
        [Export("initWithAccessToken:")]
        IntPtr Constructor([NullAllowed] string accessToken);

        // -(NSURLSessionDataTask * _Nonnull)calculateDirectionsWithOptions:(MBRouteOptions * _Nonnull)options completionHandler:(void (^ _Nonnull)(NSArray<MBWaypoint *> * _Nullable, NSArray<MBRoute *> * _Nullable, NSError * _Nullable))completionHandler;
        [Export("calculateDirectionsWithOptions:completionHandler:")]
        NSUrlSessionDataTask CalculateDirectionsWithOptions(MBRouteOptions options, Action<NSArray<MBWaypoint>, NSArray<MBRoute>, NSError> completionHandler);

        // -(NSURL * _Nonnull)URLForCalculatingDirectionsWithOptions:(MBRouteOptions * _Nonnull)options __attribute__((warn_unused_result));
        [Export("URLForCalculatingDirectionsWithOptions:")]
        NSUrl URLForCalculatingDirectionsWithOptions(MBRouteOptions options);
    }

    // @interface MBIntersection : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBIntersection : INSSecureCoding
    {
        // @property (readonly, nonatomic) CLLocationCoordinate2D location;
        [Export("location")]
        CLLocationCoordinate2D Location { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nonnull headings;
        [Export("headings", ArgumentSemantic.Copy)]
        NSNumber[] Headings { get; }

        // @property (readonly, copy, nonatomic) NSIndexSet * _Nonnull outletIndexes;
        [Export("outletIndexes", ArgumentSemantic.Copy)]
        NSIndexSet OutletIndexes { get; }

        // @property (readonly, nonatomic) NSInteger approachIndex;
        [Export("approachIndex")]
        nint ApproachIndex { get; }

        // @property (readonly, nonatomic) NSInteger outletIndex;
        [Export("outletIndex")]
        nint OutletIndex { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBLane *> * _Nullable approachLanes;
        [NullAllowed, Export("approachLanes", ArgumentSemantic.Copy)]
        MBLane[] ApproachLanes { get; }

        // @property (readonly, copy, nonatomic) NSIndexSet * _Nullable usableApproachLanes;
        [NullAllowed, Export("usableApproachLanes", ArgumentSemantic.Copy)]
        NSIndexSet UsableApproachLanes { get; }

        //// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder decoder);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }
    }

    // @interface MBLane : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBLane : INSSecureCoding
    {
        // @property (readonly, nonatomic) MBLaneIndication indications;
        [Export("indications")]
        MBLaneIndication Indications { get; }

        //// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder decoder);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }
    }

    // @interface MBRoute : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRoute : INSSecureCoding
    {
        // -(instancetype _Nonnull)initWithJson:(NSDictionary<NSString *,id> * _Nonnull)json waypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints routeOptions:(MBRouteOptions * _Nonnull)routeOptions;
        [Export("initWithJson:waypoints:routeOptions:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json, MBWaypoint[] waypoints, MBRouteOptions routeOptions);

        //// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder decoder);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        // @property (readonly, copy, nonatomic) NSArray<NSValue *> * _Nullable coordinates;
        [NullAllowed, Export("coordinates", ArgumentSemantic.Copy)]
        NSValue[] Coordinates { get; }

        // @property (readonly, nonatomic) NSUInteger coordinateCount;
        [Export("coordinateCount")]
        nuint CoordinateCount { get; }

        // -(void)getCoordinates:(CLLocationCoordinate2D * _Nonnull)coordinates;
        [Export("getCoordinates:")]
        unsafe void GetCoordinates(out CLLocationCoordinate2D coordinates);

        // @property (readonly, copy, nonatomic) NSArray<MBRouteLeg *> * _Nonnull legs;
        [Export("legs", ArgumentSemantic.Copy)]
        MBRouteLeg[] Legs { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull description;
        [Export("description")]
        string Description { get; }

        // @property (readonly, nonatomic) CLLocationDistance distance;
        [Export("distance")]
        double Distance { get; }

        // @property (readonly, nonatomic) NSTimeInterval expectedTravelTime;
        [Export("expectedTravelTime")]
        double ExpectedTravelTime { get; }

        // @property (readonly, nonatomic, strong) MBRouteOptions * _Nonnull routeOptions;
        [Export("routeOptions", ArgumentSemantic.Strong)]
        MBRouteOptions RouteOptions { get; }

        // @property (copy, nonatomic) NSString * _Nullable accessToken;
        [NullAllowed, Export("accessToken")]
        string AccessToken { get; set; }

        // @property (copy, nonatomic) NSURL * _Nullable apiEndpoint;
        [NullAllowed, Export("apiEndpoint", ArgumentSemantic.Copy)]
        NSUrl ApiEndpoint { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable routeIdentifier;
        [NullAllowed, Export("routeIdentifier")]
        string RouteIdentifier { get; set; }
    }

    // @interface MBRouteLeg : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRouteLeg : INSSecureCoding
    {
        // -(instancetype _Nonnull)initWithJson:(NSDictionary<NSString *,id> * _Nonnull)json source:(MBWaypoint * _Nonnull)source destination:(MBWaypoint * _Nonnull)destination profileIdentifier:(MBDirectionsProfileIdentifier _Nonnull)profileIdentifier;
        [Export("initWithJson:source:destination:profileIdentifier:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json, MBWaypoint source, MBWaypoint destination, string profileIdentifier);

        //// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder decoder);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        // @property (readonly, nonatomic, strong) MBWaypoint * _Nonnull source;
        [Export("source", ArgumentSemantic.Strong)]
        MBWaypoint Source { get; }

        // @property (readonly, nonatomic, strong) MBWaypoint * _Nonnull destination;
        [Export("destination", ArgumentSemantic.Strong)]
        MBWaypoint Destination { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBRouteStep *> * _Nonnull steps;
        [Export("steps", ArgumentSemantic.Copy)]
        MBRouteStep[] Steps { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable openStreetMapNodeIdentifiers;
        [NullAllowed, Export("openStreetMapNodeIdentifiers", ArgumentSemantic.Copy)]
        NSNumber[] OpenStreetMapNodeIdentifiers { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable segmentDistances;
        [NullAllowed, Export("segmentDistances", ArgumentSemantic.Copy)]
        NSNumber[] SegmentDistances { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable expectedSegmentTravelTimes;
        [NullAllowed, Export("expectedSegmentTravelTimes", ArgumentSemantic.Copy)]
        NSNumber[] ExpectedSegmentTravelTimes { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSNumber *> * _Nullable segmentSpeeds;
        [NullAllowed, Export("segmentSpeeds", ArgumentSemantic.Copy)]
        NSNumber[] SegmentSpeeds { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull description;
        [Export("description")]
        string Description { get; }

        // @property (readonly, nonatomic) CLLocationDistance distance;
        [Export("distance")]
        double Distance { get; }

        // @property (readonly, nonatomic) NSTimeInterval expectedTravelTime;
        [Export("expectedTravelTime")]
        double ExpectedTravelTime { get; }

        // @property (readonly, nonatomic) MBDirectionsProfileIdentifier _Nonnull profileIdentifier;
        [Export("profileIdentifier")]
        string ProfileIdentifier { get; }
    }

    // @interface MBRouteOptions : NSObject <NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRouteOptions : INSCopying, INSSecureCoding
    {
        // -(instancetype _Nonnull)initWithWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier __attribute__((objc_designated_initializer));
        [Export("initWithWaypoints:profileIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBWaypoint[] waypoints, [NullAllowed] string profileIdentifier);

        // -(instancetype _Nonnull)initWithLocations:(NSArray<CLLocation *> * _Nonnull)locations profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier;
        [Export("initWithLocations:profileIdentifier:")]
        IntPtr Constructor(CLLocation[] locations, [NullAllowed] string profileIdentifier);

        // -(instancetype _Nonnull)initWithCoordinates:(NSArray<NSValue *> * _Nonnull)coordinates profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier;
        [Export("initWithCoordinates:profileIdentifier:")]
        IntPtr Constructor(NSValue[] coordinates, [NullAllowed] string profileIdentifier);

        //// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder decoder);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        // @property (copy, nonatomic) NSArray<MBWaypoint *> * _Nonnull waypoints;
        [Export("waypoints", ArgumentSemantic.Copy)]
        MBWaypoint[] Waypoints { get; set; }

        // @property (nonatomic) BOOL allowsUTurnAtWaypoint;
        [Export("allowsUTurnAtWaypoint")]
        bool AllowsUTurnAtWaypoint { get; set; }

        // @property (nonatomic) MBDirectionsProfileIdentifier _Nonnull profileIdentifier;
        [Export("profileIdentifier")]
        string ProfileIdentifier { get; set; }

        // @property (nonatomic) BOOL includesAlternativeRoutes;
        [Export("includesAlternativeRoutes")]
        bool IncludesAlternativeRoutes { get; set; }

        // @property (nonatomic) BOOL includesSteps;
        [Export("includesSteps")]
        bool IncludesSteps { get; set; }

        // @property (nonatomic) enum MBRouteShapeFormat shapeFormat;
        [Export("shapeFormat", ArgumentSemantic.Assign)]
        MBRouteShapeFormat ShapeFormat { get; set; }

        // @property (nonatomic) enum MBRouteShapeResolution routeShapeResolution;
        [Export("routeShapeResolution", ArgumentSemantic.Assign)]
        MBRouteShapeResolution RouteShapeResolution { get; set; }

        // @property (nonatomic) MBAttributeOptions attributeOptions;
        [Export("attributeOptions", ArgumentSemantic.Assign)]
        MBAttributeOptions AttributeOptions { get; set; }

        // @property (nonatomic) BOOL includesExitRoundaboutManeuver;
        [Export("includesExitRoundaboutManeuver")]
        bool IncludesExitRoundaboutManeuver { get; set; }

        // @property (copy, nonatomic) NSLocale * _Nonnull locale;
        [Export("locale", ArgumentSemantic.Copy)]
        NSLocale Locale { get; set; }

        // @property (nonatomic) BOOL includesSpokenInstructions;
        [Export("includesSpokenInstructions")]
        bool IncludesSpokenInstructions { get; set; }

        // @property (nonatomic) enum MBMeasurementSystem distanceMeasurementSystem;
        [Export("distanceMeasurementSystem", ArgumentSemantic.Assign)]
        MBMeasurementSystem DistanceMeasurementSystem { get; set; }

        // @property (nonatomic) BOOL includesVisualInstructions;
        [Export("includesVisualInstructions")]
        bool IncludesVisualInstructions { get; set; }

        // @property (nonatomic) MBRoadClasses roadClassesToAvoid;
        [Export("roadClassesToAvoid", ArgumentSemantic.Assign)]
        MBRoadClasses RoadClassesToAvoid { get; set; }

        // -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result));
        [Export("isEqual:")]
        bool IsEqual([NullAllowed] NSObject @object);

        // -(BOOL)isEqualToRouteOptions:(MBRouteOptions * _Nullable)routeOptions __attribute__((warn_unused_result));
        [Export("isEqualToRouteOptions:")]
        bool IsEqualToRouteOptions([NullAllowed] MBRouteOptions routeOptions);
    }

    // @interface MBRouteOptionsV4 : MBRouteOptions
    [BaseType(typeof(MBRouteOptions))]
    interface MBRouteOptionsV4
    {
        // @property (nonatomic) enum MBInstructionFormat instructionFormat;
        [Export("instructionFormat", ArgumentSemantic.Assign)]
        MBInstructionFormat InstructionFormat { get; set; }

        // @property (nonatomic) BOOL includesShapes;
        [Export("includesShapes")]
        bool IncludesShapes { get; set; }

        // -(instancetype _Nonnull)initWithWaypoints:(NSArray<MBWaypoint *> * _Nonnull)waypoints profileIdentifier:(MBDirectionsProfileIdentifier _Nullable)profileIdentifier __attribute__((objc_designated_initializer));
        [Export("initWithWaypoints:profileIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBWaypoint[] waypoints, [NullAllowed] string profileIdentifier);

        //// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder decoder);
    }

    // @interface MBRouteStep : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRouteStep : INSSecureCoding
    {
        // -(instancetype _Nonnull)initWithJson:(NSDictionary<NSString *,id> * _Nonnull)json;
        [Export("initWithJson:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json);

        //// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder decoder);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        // @property (readonly, copy, nonatomic) NSArray<NSValue *> * _Nullable coordinates;
        [NullAllowed, Export("coordinates", ArgumentSemantic.Copy)]
        NSValue[] Coordinates { get; }

        // @property (readonly, nonatomic) NSUInteger coordinateCount;
        [Export("coordinateCount")]
        nuint CoordinateCount { get; }

        // -(BOOL)getCoordinates:(CLLocationCoordinate2D * _Nonnull)coordinates __attribute__((warn_unused_result));
        [Export("getCoordinates:")]
        unsafe bool GetCoordinates(out CLLocationCoordinate2D coordinates);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull instructions;
        [Export("instructions")]
        string Instructions { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBSpokenInstruction *> * _Nullable instructionsSpokenAlongStep;
        [NullAllowed, Export("instructionsSpokenAlongStep", ArgumentSemantic.Copy)]
        MBSpokenInstruction[] InstructionsSpokenAlongStep { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBVisualInstruction *> * _Nullable instructionsDisplayedAlongStep;
        [NullAllowed, Export("instructionsDisplayedAlongStep", ArgumentSemantic.Copy)]
        MBVisualInstruction[] InstructionsDisplayedAlongStep { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull description;
        [Export("description")]
        string Description { get; }

        // @property (readonly, nonatomic) CLLocationCoordinate2D maneuverLocation;
        [Export("maneuverLocation")]
        CLLocationCoordinate2D ManeuverLocation { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable exitCodes;
        [NullAllowed, Export("exitCodes", ArgumentSemantic.Copy)]
        string[] ExitCodes { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable exitNames;
        [NullAllowed, Export("exitNames", ArgumentSemantic.Copy)]
        string[] ExitNames { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable phoneticExitNames;
        [NullAllowed, Export("phoneticExitNames", ArgumentSemantic.Copy)]
        string[] PhoneticExitNames { get; }

        // @property (readonly, nonatomic) CLLocationDistance distance;
        [Export("distance")]
        double Distance { get; }

        // @property (readonly, nonatomic) NSTimeInterval expectedTravelTime;
        [Export("expectedTravelTime")]
        double ExpectedTravelTime { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable names;
        [NullAllowed, Export("names", ArgumentSemantic.Copy)]
        string[] Names { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable phoneticNames;
        [NullAllowed, Export("phoneticNames", ArgumentSemantic.Copy)]
        string[] PhoneticNames { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable codes;
        [NullAllowed, Export("codes", ArgumentSemantic.Copy)]
        string[] Codes { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable destinationCodes;
        [NullAllowed, Export("destinationCodes", ArgumentSemantic.Copy)]
        string[] DestinationCodes { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nullable destinations;
        [NullAllowed, Export("destinations", ArgumentSemantic.Copy)]
        string[] Destinations { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBIntersection *> * _Nullable intersections;
        [NullAllowed, Export("intersections", ArgumentSemantic.Copy)]
        MBIntersection[] Intersections { get; }
    }

    // @interface MBSpokenInstruction : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBSpokenInstruction : INSSecureCoding
    {
        // @property (readonly, nonatomic) CLLocationDistance distanceAlongStep;
        [Export("distanceAlongStep")]
        double DistanceAlongStep { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull text;
        [Export("text")]
        string Text { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull ssmlText;
        [Export("ssmlText")]
        string SsmlText { get; }

        // -(instancetype _Nonnull)initWithJson:(NSDictionary<NSString *,id> * _Nonnull)json;
        [Export("initWithJson:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json);

        // -(instancetype _Nonnull)initWithDistanceAlongStep:(CLLocationDistance)distanceAlongStep text:(NSString * _Nonnull)text ssmlText:(NSString * _Nonnull)ssmlText __attribute__((objc_designated_initializer));
        [Export("initWithDistanceAlongStep:text:ssmlText:")]
        [DesignatedInitializer]
        IntPtr Constructor(double distanceAlongStep, string text, string ssmlText);

        //// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder decoder);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

    }

    // @interface MBVisualInstruction : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBVisualInstruction : INSSecureCoding
    {
        // @property (readonly, nonatomic) CLLocationDistance distanceAlongStep;
        [Export("distanceAlongStep")]
        double DistanceAlongStep { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull primaryText;
        [Export("primaryText")]
        string PrimaryText { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBVisualInstructionComponent *> * _Nonnull primaryTextComponents;
        [Export("primaryTextComponents", ArgumentSemantic.Copy)]
        MBVisualInstructionComponent[] PrimaryTextComponents { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable secondaryText;
        [NullAllowed, Export("secondaryText")]
        string SecondaryText { get; }

        // @property (readonly, copy, nonatomic) NSArray<MBVisualInstructionComponent *> * _Nullable secondaryTextComponents;
        [NullAllowed, Export("secondaryTextComponents", ArgumentSemantic.Copy)]
        MBVisualInstructionComponent[] SecondaryTextComponents { get; }

        // -(instancetype _Nonnull)initWithJson:(NSDictionary<NSString *,id> * _Nonnull)json;
        [Export("initWithJson:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json);

        // -(instancetype _Nonnull)initWithDistanceAlongStep:(CLLocationDistance)distanceAlongStep primaryText:(NSString * _Nonnull)primaryText primaryTextComponents:(NSArray<MBVisualInstructionComponent *> * _Nonnull)primaryTextComponents secondaryText:(NSString * _Nullable)secondaryText secondaryTextComponents:(NSArray<MBVisualInstructionComponent *> * _Nullable)secondaryTextComponents __attribute__((objc_designated_initializer));
        [Export("initWithDistanceAlongStep:primaryText:primaryTextComponents:secondaryText:secondaryTextComponents:")]
        [DesignatedInitializer]
        IntPtr Constructor(double distanceAlongStep, string primaryText, MBVisualInstructionComponent[] primaryTextComponents, [NullAllowed] string secondaryText, [NullAllowed] MBVisualInstructionComponent[] secondaryTextComponents);

        //// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder decoder);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

    }

    // @interface MBVisualInstructionComponent : NSObject <NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBVisualInstructionComponent : INSSecureCoding
    {
        // @property (readonly, copy, nonatomic) NSString * _Nullable text;
        [NullAllowed, Export("text")]
        string Text { get; }

        // @property (copy, nonatomic) NSURL * _Nullable imageURL;
        [NullAllowed, Export("imageURL", ArgumentSemantic.Copy)]
        NSUrl ImageURL { get; set; }

        // -(instancetype _Nonnull)initWithJson:(NSDictionary<NSString *,id> * _Nonnull)json;
        [Export("initWithJson:")]
        IntPtr Constructor(NSDictionary<NSString, NSObject> json);

        // -(instancetype _Nonnull)initWithText:(NSString * _Nullable)text imageURL:(NSURL * _Nullable)imageURL __attribute__((objc_designated_initializer));
        [Export("initWithText:imageURL:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string text, [NullAllowed] NSUrl imageURL);

        //// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)decoder __attribute__((objc_designated_initializer));
        //[Export("initWithCoder:")]
        //[DesignatedInitializer]
        //IntPtr Constructor(NSCoder decoder);

        // @property (nonatomic, class) BOOL supportsSecureCoding;
        [Static]
        [Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

    }

    /// <summary>
    /// A <code>Waypoint</code> object indicates a location along a route. It may be the route’s origin or destination, or it may be another location that the route visits. A waypoint object indicates the location’s geographic location along with other optional information, such as a name or the user’s direction approaching the waypoint. You create a <code>RouteOptions</code> object using waypoint objects and also receive waypoint objects in the completion handler of the <code>Directions.calculate(_:completionHandler:)</code> method.
    /// </summary>
    //@interface MBWaypoint : NSObject<NSCopying, NSSecureCoding>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBWaypoint : INSCopying, INSSecureCoding
    {
        //SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly) BOOL supportsSecureCoding;)
        //+ (BOOL) supportsSecureCoding SWIFT_WARN_UNUSED_RESULT;
        [Static, Export("supportsSecureCoding")]
        bool SupportsSecureCoding { get; set; }

        /// <summary>
        /// Initializes a new waypoint object with the given geographic coordinate and an optional accuracy and name.
        /// </summary>
        /// <param name="coordinate">
        /// The geographic coordinate of the waypoint.
        /// </param>
        /// <param name="coordinateAccuracy">
        /// The maximum distance away from the waypoint that the route may come and still be considered viable. This parameter is measured in meters. A negative value means the route may be an indefinite number of meters away from the route and still be considered viable.
        /// It is recommended that the value of this parameter be greater than the <code>horizontalAccuracy</code> property of a <code>CLLocation</code> object obtained from a <code>CLLocationManager</code> object. There is a high likelihood that the user may be located some distance away from a navigable road, for instance if the user is currently on a driveway or inside a building.
        /// </param>
        /// <param name="name"> 
        /// This parameter does not affect the route but may help you to distinguish one waypoint from another.
        /// </param>
        // - (nonnull instancetype) initWithCoordinate:(CLLocationCoordinate2D) coordinate coordinateAccuracy:(CLLocationAccuracy) coordinateAccuracy name:(NSString* _Nullable) name OBJC_DESIGNATED_INITIALIZER;
        [Export("initWithCoordinate:coordinateAccuracy:name:")]
        [DesignatedInitializer]
        IntPtr Constructor(CLLocationCoordinate2D coordinate, double coordinateAccuracy, [NullAllowed] string name);

        /// <summary>
        /// Initializes a new waypoint object with the given <code>CLLocation</code> object and an optional <code>CLHeading</code> object and name.
        /// </summary>
        /// <remarks>
        /// This initializer is intended for <code>CLLocation</code> objects created using the <code>CLLocation.init(latitude:longitude:)</code> initializer. If you intend to use a <code>CLLocation</code> object obtained from a <code>CLLocationManager</code> object, consider increasing the <code>horizontalAccuracy</code> or set it to a negative value to avoid overfitting, since the <code>Waypoint</code> class’s <code>coordinateAccuracy</code> property represents the maximum allowed deviation from the waypoint. There is a high likelihood that the user may be located some distance away from a navigable road, for instance if the user is currently on a driveway of inside a building.
        /// </remarks>
        /// <param name="location">
        /// A <code>CLLocation</code> object representing the waypoint’s location. This initializer respects the <code>CLLocation</code> class’s <code>coordinate</code> and <code>horizontalAccuracy</code> properties, converting them into the <code>coordinate</code> and <code>coordinateAccuracy</code> properties, respectively.
        /// </param>
        /// <param name="heading">
        /// A <code>CLHeading</code> object representing the direction from which the route must approach the waypoint in order to be considered viable. This initializer respects the <code>CLHeading</code> class’s <code>trueHeading</code> property or <code>magneticHeading</code> property, converting it into the <code>headingAccuracy</code> property.
        /// </param>
        /// <param name="name"> 
        /// The name of the waypoint. This parameter does not affect the route but may help you to distinguish one waypoint from another.
        /// </param>
        //- (nonnull instancetype) initWithLocation:(CLLocation* _Nonnull) location heading:(CLHeading* _Nullable) heading name:(NSString* _Nullable) name OBJC_DESIGNATED_INITIALIZER;
        [Export("initWithLocation:heading:name:")]
        [DesignatedInitializer]
        IntPtr Constructor(CLLocation location, [NullAllowed] CLHeading heading, [NullAllowed] string name);

        // - (void) encodeWithCoder:(NSCoder* _Nonnull) coder;
        [Export("encodeWithCoder:")]
        void EncodeWithCoder(NSCoder coder);

        /// <summary>
        /// The geographic coordinate of the waypoint.
        /// </summary>
        //@property(nonatomic, readonly) CLLocationCoordinate2D coordinate;
        [Export("coordinate")]
        CLLocationCoordinate2D Coordinate { get; }

        /// <summary>
        /// The radius of uncertainty for the waypoint, measured in meters.
        /// For a route to be considered viable, it must enter this waypoint’s circle of uncertainty. The <code>coordinate</code> property identifies the center of the circle, while this property indicates the circle’s radius. If the value of this property is negative, a route is considered viable regardless of whether it enters this waypoint’s circle of uncertainty, subject to an undefined maximum distance.
        /// By default, the value of this property is a negative number.
        /// </summary>
        //@property(nonatomic) CLLocationAccuracy coordinateAccuracy;
        [Export("coordinateAccuracy")]
        double CoordinateAccuracy { get; set; }

        /// <summary>
        /// The direction from which a route must approach this waypoint in order to be considered viable.
        /// This property is measured in degrees clockwise from true north. A value of 0 degrees means due north, 90 degrees means due east, 180 degrees means due south, and so on. If the value of this property is negative, a route is considered viable regardless of the direction from which it approaches this waypoint.
        /// If this waypoint is the first waypoint (the source waypoint), the route must start out by heading in the direction specified by this property. You should always set the <code>headingAccuracy</code> property in conjunction with this property. If the <code>headingAccuracy</code> property is set to a negative value, this property is ignored.
        /// For driving directions, this property can be useful for avoiding a route that begins by going in the direction opposite the current direction of travel. For example, if you know the user is moving eastwardly and the first waypoint is the user’s current location, specifying a heading of 90 degrees and a heading accuracy of 90 degrees for the first waypoint avoids a route that begins with a “head west” instruction.
        /// You should be certain that the user is in motion before specifying a heading and heading accuracy; otherwise, you may be unnecessarily filtering out the best route. For example, suppose the user is sitting in a car parked in a driveway, facing due north, with the garage in front and the street to the rear. In that case, specifying a heading of 0 degrees and a heading accuracy of 90 degrees may result in a route that begins on the back alley or, worse, no route at all. For this reason, it is recommended that you only specify a heading and heading accuracy when automatically recalculating directions due to the user deviating from the route.
        /// By default, the value of this property is a negative number, meaning that a route is considered viable regardless of the direction of approach.
        /// </summary>
        //@property(nonatomic) CLLocationDirection heading;
        [Export("heading")]
        double Heading { get; set; }

        /// <summary>
        /// The maximum amount, in degrees, by which a route’s approach to a waypoint may differ from <code>heading</code> in either direction in order to be considered viable.
        /// A value of 0 degrees means that the approach must match the specified <code>heading</code> exactly – an unlikely scenario. A value of 180 degrees or more means that the approach may be as much as 180 degrees in either direction from the specified <code>heading</code>, effectively allowing a candidate route to approach the waypoint from any direction.
        /// If you set the <code>heading</code> property, you should set this property to a value such as 90 degrees, to avoid filtering out routes whose approaches differ only slightly from the specified <code>heading</code>. Otherwise, if the <code>heading</code> property is set to a negative value, this property is ignored.
        /// By default, the value of this property is a negative number, meaning that a route is considered viable regardless of the direction of approach.
        /// </summary>
        //@property(nonatomic) CLLocationDirection headingAccuracy;
        [Export("headingAccuracy")]
        double HeadingAccuracy { get; set; }

        /// <summary>
        /// The name of the waypoint.
        /// This parameter does not affect the route, but you can set the name of a waypoint you pass into a <code>RouteOptions</code> object to help you distinguish one waypoint from another in the array of waypoints passed into the completion handler of the <code>Directions.calculate(_:completionHandler:)</code> method.
        /// </summary>
        //@property(nonatomic, copy) NSString* _Nullable name;
        [Export("name")]
        string Name { get; set; }

        /// <summary>
        /// </summary>
        //@property(nonatomic, readonly, copy) NSString* _Nonnull description;
        [Export("description")]
        string Description { get; }
    }

    /// <summary>
    /// A <code>Tracepoint</code> represents a location matched to the road network.
    //SWIFT_CLASS_NAMED("Tracepoint")
    //@interface MBTracepoint : MBWaypoint
    [BaseType(typeof(MBWaypoint))]
    [DisableDefaultCtor]
    partial interface MBTracepoint
    {
        /// <summary>
        /// Number of probable alternative matchings for this tracepoint. A value of zero indicates that this point was matched unambiguously.
        /// </summary>
        //@property(nonatomic) NSInteger alternateCount;
        [Export("alternateCount")]
        nint AlternateCount { get; set; }
    }
}
