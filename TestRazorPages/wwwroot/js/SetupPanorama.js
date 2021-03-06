'use strict';

function SetupPanorama(panoramaPath) {
    
    var panoElement = document.getElementById('pano');

    var viewerOpts = {
        controls: {
            mouseViewMode: 'drag'    // drag|qtvr
        }
    };

    // Create viewer.
    var viewer = new Marzipano.Viewer(panoElement, viewerOpts);

    // Create source.
    var source = Marzipano.ImageUrlSource.fromString(panoramaPath);

    // Create geometry suitable for equirectangular images with a 2:1 aspect ratio.
    var geometry = new Marzipano.EquirectGeometry([{width: 6000}]);

    // https://www.marzipano.net/reference/RectilinearViewParams.html
    var params = {yaw: 0, pitch: 0, roll: 0, fov: Math.PI / 4};

    // https://www.marzipano.net/reference/RectilinearView.limit.html
    // The cube face width in pixels or, equivalently, one fourth of the equirectangular width in pixels.
    var maxResolution = 1500;       // 6000 / 4

    // Create view.
    var limiter = Marzipano.RectilinearView.limit.traditional(maxResolution, 100 * Math.PI / 180);
    var view = new Marzipano.RectilinearView(params, limiter);

    // Create scene.
    var scene = viewer.createScene({
        source: source,
        geometry: geometry,
        view: view,
        pinFirstLevel: true
    });

    // Display scene performing a fade in transition.
    scene.switchTo({
        transitionDuration: 1000
    });

    var autorotate = Marzipano.autorotate({
        yawSpeed: 0.1,         // Yaw rotation speed
        targetPitch: 0,        // Pitch value to converge to
        targetFov: Math.PI / 4   // Fov value to converge to
    });

    // Autorotate will start after 3s of idle time
    viewer.setIdleMovement(3000, autorotate);

}
